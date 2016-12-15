package com.company.icafe.adapter;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.ImageView;
import android.widget.TextView;

import com.company.icafe.R;
import com.company.icafe.callback.CartItemsUpdated;
import com.company.icafe.database.CartDBHandler;
import com.company.icafe.model.CartItem;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Created by 20105480 on 24-08-2016.
 */
public class CartListItemAdapter extends RecyclerView.Adapter<CartListItemAdapter.CartListItemViewHolder> {

    private final String LOG_TAG = "CartListItemAdapter";

    private static CartListItemAdapter cartListItemAdapter;
    private List<CartItem> mValues;
    private CartItemsUpdated cartItemUpdated;
    private Context mContext;
    private CartItem selectedCartItem;
    private String[] itemsQuantity = {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "More"
    };
    final List<String> itemsQuantityList = new ArrayList<>(Arrays.asList(itemsQuantity));


    public static CartListItemAdapter newInstance(Context context, List<CartItem> items, CartItemsUpdated cartItemsUpdated) {
        cartListItemAdapter = new CartListItemAdapter(context, items, cartItemsUpdated);
        return cartListItemAdapter;
    }

    private CartListItemAdapter(Context context, List<CartItem> items, CartItemsUpdated cartItemsUpdated) {
        this.mContext = context;
        this.mValues = items;
        this.cartItemUpdated = cartItemsUpdated;
    }

    @Override
    public CartListItemViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.cart_item_row_layout, parent, false);
        return new CartListItemViewHolder(view);
    }

    @Override
    public void onBindViewHolder(final CartListItemViewHolder holder, final int position) {

        selectedCartItem = mValues.get(position);

        holder.cartItemNameTextView.setText(selectedCartItem.getMenuItemName());
        holder.cartItemTotalPriceTextView.setText(String.valueOf(selectedCartItem.getMenuItemQuantityPrice()));
        holder.cartItemQuantityTextView.setText(String.valueOf(selectedCartItem.getMenuItemQuantity()));

        holder.cartItemDeleteImageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                CartDBHandler.getInstance(mContext).removeMenuItemFromCart(mValues.get(position));
                mValues = CartDBHandler.getInstance(mContext).getCartItemList();
                cartListItemAdapter.notifyDataSetChanged();
                cartItemUpdated.cartItemsUpdated();
            }
        });

        holder.cartItemEditQuantityImageButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                showQuantityDialog(position);
            }
        });
    }

    public int getItemCount() {
        return mValues.size();
    }

    private void showQuantityDialog(final int itemIndexValue) {
        final AlertDialog.Builder quantityDialogBuilder = new AlertDialog.Builder(mContext);

        LayoutInflater li = LayoutInflater.from(mContext);
        View promptsView = li.inflate(R.layout.data_edit_ok_cancel_prompt, null);

        quantityDialogBuilder.setView(promptsView);

        final TextView promptMsgTextView = (TextView) promptsView.findViewById(R.id.promptMessageTextView);
        promptMsgTextView.setVisibility(View.GONE);

        final EditText promptEditText = (EditText) promptsView.findViewById(R.id.promptEditText);
        promptEditText.setHint(mContext.getString(R.string.enter_quantity));

        quantityDialogBuilder
                .setCancelable(false)
                .setPositiveButton(mContext.getText(R.string.ok),
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                String values = promptEditText.getText().toString();
                                if (values != null && !values.isEmpty())
                                    changeQuanityValue(itemIndexValue, Integer.parseInt(values));
                            }
                        })
                .setNegativeButton(mContext.getText(R.string.cancel),
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                dialog.cancel();
                            }
                        });

        AlertDialog quantityDialog = quantityDialogBuilder.create();
        quantityDialog.setTitle(mContext.getString(R.string.quantity));
        quantityDialog.show();
    }

    private void changeQuanityValue(int itemIndex, int quantity) {
        mValues.get(itemIndex).setMenuItemQuantity(quantity);
        CartDBHandler.getInstance(mContext).updateMenuItemQuantityInCart(mValues.get(itemIndex));

        mValues = CartDBHandler.getInstance(mContext).getCartItemList();
        cartListItemAdapter.notifyDataSetChanged();
        cartItemUpdated.cartItemsUpdated();
    }

    public class CartListItemViewHolder extends RecyclerView.ViewHolder {

        TextView cartItemNameTextView, cartItemTotalPriceTextView, cartItemQuantityTextView;

        ImageView cartItemImageView;
        ImageButton cartItemDeleteImageButton, cartItemEditQuantityImageButton;

        public CartListItemViewHolder(View view) {
            super(view);

            cartItemImageView = (ImageView) view.findViewById(R.id.cartItemImageView);
            cartItemNameTextView = (TextView) view.findViewById(R.id.cartItemNameTextView);
            cartItemTotalPriceTextView = (TextView) view.findViewById(R.id.cartItemTotalPriceTextView);
            cartItemQuantityTextView = (TextView) view.findViewById(R.id.cartItemQuantityTextView);

            cartItemDeleteImageButton = (ImageButton) view.findViewById(R.id.cartItemDeleteButton);
            cartItemEditQuantityImageButton = (ImageButton) view.findViewById(R.id.cartItemEditQuantityButton);
        }

        @Override
        public String toString() {
            return super.toString() + " '" + cartItemNameTextView.getText();
        }
    }

}
