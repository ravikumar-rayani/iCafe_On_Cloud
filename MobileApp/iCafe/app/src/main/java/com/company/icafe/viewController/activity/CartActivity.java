package com.company.icafe.viewController.activity;

import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.Gravity;
import android.view.View;
import android.widget.Button;
import android.widget.FrameLayout;
import android.widget.TextView;

import com.company.icafe.R;
import com.company.icafe.adapter.CartListItemAdapter;
import com.company.icafe.callback.CartItemsUpdated;
import com.company.icafe.database.CartDBHandler;
import com.company.icafe.model.CartItem;

import java.util.ArrayList;

/**
 * Created by pmishra on 17/11/16.
 */

public class CartActivity extends AppCompatActivity implements CartItemsUpdated{

    private TextView totalPriceTextView;
    private FrameLayout noCartItemLayout;
    private Button noCartItemButton;
    private View placeOrderMenuView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.cart_layout);

        ArrayList<CartItem> cartItemArrayList = CartDBHandler.getInstance(getApplicationContext()).getCartItemList();

        noCartItemLayout = (FrameLayout) findViewById(R.id.no_cart_item_layout);
        noCartItemLayout.setVisibility(View.VISIBLE);

        noCartItemButton = (Button) findViewById(R.id.shop_items_button);
        noCartItemButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                CartActivity.this.finish();
            }
        });

        if(cartItemArrayList.size() > 0) {
            noCartItemLayout.setVisibility(View.GONE);

            RecyclerView cartItemListView = (RecyclerView) findViewById(R.id.cartItemsListView);

            cartItemListView.setLayoutManager(new LinearLayoutManager(this));
            cartItemListView.setHasFixedSize(true);
            cartItemListView.setAdapter(CartListItemAdapter.newInstance(this, cartItemArrayList, this));

            ActionBar actionBar = getSupportActionBar();
            actionBar.setDisplayOptions(actionBar.getDisplayOptions() | ActionBar.DISPLAY_SHOW_CUSTOM);

            placeOrderMenuView = getLayoutInflater().inflate(R.layout.cart_place_order_menu, null);
            ActionBar.LayoutParams layoutParams = new ActionBar.LayoutParams(
                    ActionBar.LayoutParams.WRAP_CONTENT,
                    ActionBar.LayoutParams.WRAP_CONTENT, Gravity.RIGHT
                    | Gravity.CENTER_VERTICAL);
            placeOrderMenuView.setLayoutParams(layoutParams);
            actionBar.setCustomView(placeOrderMenuView);

            totalPriceTextView = (TextView) findViewById(R.id.cart_total_price);
            totalPriceTextView.setText(String.valueOf(CartDBHandler.getInstance(getApplicationContext()).getCartTotalPrice()));
        } else {
            noCartItemLayout.setVisibility(View.VISIBLE);
        }
    }

    @Override
    public void cartItemsUpdated() {
        if(CartDBHandler.getInstance(getApplicationContext()).getCartItemsCount() > 0) {
            if (totalPriceTextView != null) {
                totalPriceTextView.setText(String.valueOf(CartDBHandler.getInstance(getApplicationContext()).getCartTotalPrice()));
            }
        } else {
            noCartItemLayout.setVisibility(View.VISIBLE);
            placeOrderMenuView.setVisibility(View.GONE);
        }
    }
}
