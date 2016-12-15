package com.company.icafe.adapter;

import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.drawable.Drawable;
import android.os.AsyncTask;
import android.support.v7.widget.RecyclerView;
import android.util.Log;
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
import com.company.icafe.model.Constants;
import com.company.icafe.model.MenuItem;
import com.company.icafe.viewController.ICafe;
import com.company.icafe.viewController.activity.AppHomeActivity;
import com.company.icafe.viewController.activity.MenuItemInfoActivity;

import java.io.InputStream;
import java.lang.ref.WeakReference;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.List;

import javax.net.ssl.HttpsURLConnection;

/**
 * Created by pmishra on 01/10/16.
 */

public class DigitalMenuGridViewAdapter extends RecyclerView.Adapter<DigitalMenuGridViewAdapter.GridViewHolder> {

    private List<MenuItem> mValues;
    private Context mContext;
    private CartItemsUpdated cartItemsUpdated;

    public DigitalMenuGridViewAdapter(Context context, List<MenuItem> items, CartItemsUpdated cartItemsUpdated) {
        mContext = context;
        mValues = items;
        this.cartItemsUpdated = cartItemsUpdated;
    }

    @Override
    public GridViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.grid_view_item_layout, parent, false);
        return new GridViewHolder(view);
    }

    @Override
    public void onBindViewHolder(final GridViewHolder holder, int position) {

        switch (ICafe.getCurrentUserMode()) {
            case Constants.ADMIN_MODE:
                break;
            case Constants.DIGITAL_MENU_MODE:
                holder.itemIncreaseQuantityButton.setVisibility(View.INVISIBLE);
                holder.itemQuantityEditText.setVisibility(View.INVISIBLE);
                holder.itemDecreaseQuantityButton.setVisibility(View.INVISIBLE);
                break;
            case Constants.WAITER_USER_MODE:
                holder.itemIncreaseQuantityButton.setVisibility(View.VISIBLE);
                holder.itemQuantityEditText.setVisibility(View.VISIBLE);
                holder.itemDecreaseQuantityButton.setVisibility(View.VISIBLE);
                break;
            case Constants.TABLE_USER_MODE:
                holder.itemIncreaseQuantityButton.setVisibility(View.VISIBLE);
                holder.itemQuantityEditText.setVisibility(View.VISIBLE);
                holder.itemDecreaseQuantityButton.setVisibility(View.VISIBLE);
                break;
        }

        final MenuItem menuItem = mValues.get(position);
        holder.itemUUID.setText(String.valueOf(menuItem.getId()));
        holder.itemTitle.setText(menuItem.getName());
//        holder.itemSubTitle.setText(menuItem.getSubtitle());

        holder.itemPrice.setText(String.valueOf(menuItem.getPrice()));
        holder.itemQuantityEditText.setText(Integer.toString(menuItem.getQuantity()));
        holder.itemIncreaseQuantityButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                menuItem.increaseQuantity();
                holder.itemQuantityEditText.setText(Integer.toString(menuItem.getQuantity()));
                CartDBHandler.getInstance(mContext).insertOrUpdateMenuItemToCart(menuItem);
                if(cartItemsUpdated != null)
                    cartItemsUpdated.cartItemsUpdated();
            }
        });
        holder.itemDecreaseQuantityButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                menuItem.decreaseQuantity();
                holder.itemQuantityEditText.setText(Integer.toString(menuItem.getQuantity()));
                CartDBHandler.getInstance(mContext).insertOrUpdateMenuItemToCart(menuItem);
                if(cartItemsUpdated != null)
                    cartItemsUpdated.cartItemsUpdated();
            }
        });
        holder.mView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(mContext.getApplicationContext(), MenuItemInfoActivity.class);
                mContext.startActivity(intent);
            }
        });
        if (holder.imageView != null && menuItem.getPicture() != null) {
//            new DigitalMenuRecyclerViewAdapter.ImageDownloaderTask(holder.imageView).execute(menuItem.getPicture());
        }
    }

    @Override
    public int getItemCount() {
        return mValues.size();
    }

    public class GridViewHolder extends RecyclerView.ViewHolder {

        public final View mView;
        ImageView imageView;
        TextView itemUUID, itemTitle, itemSubTitle, itemPrice;
        ImageButton itemIncreaseQuantityButton, itemDecreaseQuantityButton, itemInfo;
        EditText itemQuantityEditText;

        public GridViewHolder(View view) {
            super(view);
            mView = view;

            itemUUID = (TextView) view.findViewById(R.id.grid_item_uuid);
            itemTitle = (TextView) view.findViewById(R.id.grid_item_title);
//            itemSubTitle = (TextView) view.findViewById(R.id.grid_item_sub_title);
            itemPrice = (TextView) view.findViewById(R.id.grid_item_price);
            imageView = (ImageView) view.findViewById(R.id.grid_item_imageView);
            itemIncreaseQuantityButton = (ImageButton) view.findViewById(R.id.grid_item_increase_quantity);
            itemDecreaseQuantityButton = (ImageButton) view.findViewById(R.id.grid_item_decrease_quantity);
            itemQuantityEditText = (EditText) view.findViewById(R.id.grid_item_quantity_edit_text);
            itemInfo = (ImageButton) view.findViewById(R.id.grid_item_info);
        }

        @Override
        public String toString() {
            return super.toString() + " '" + itemTitle.getText();
        }
    }

    private class ImageDownloaderTask extends AsyncTask<String, Void, Bitmap> {
        private final WeakReference<ImageView> imageViewReference;

        public ImageDownloaderTask(ImageView imageView) {
            imageViewReference = new WeakReference<ImageView>(imageView);
        }

        @Override
        protected Bitmap doInBackground(String... params) {
            return downloadBitmap(params[0]);
        }

        @Override
        protected void onPostExecute(Bitmap bitmap) {
            if (isCancelled()) {
                bitmap = null;
            }

            if (imageViewReference != null) {
                ImageView imageView = imageViewReference.get();
                if (imageView != null) {
                    if (bitmap != null) {
                        imageView.setImageBitmap(bitmap);
                    } else {
                        Drawable placeholder = imageView.getContext().getResources().getDrawable(R.drawable.restaurant);
                        imageView.setImageDrawable(placeholder);
                    }
                }
            }
        }

        private Bitmap downloadBitmap(String url) {
            HttpURLConnection urlConnection = null;
            try {
                URL uri = new URL(url);
                urlConnection = (HttpURLConnection) uri.openConnection();
                int statusCode = urlConnection.getResponseCode();
                if (statusCode != HttpsURLConnection.HTTP_OK) {
                    return null;
                }

                InputStream inputStream = urlConnection.getInputStream();
                if (inputStream != null) {
                    Bitmap bitmap = BitmapFactory.decodeStream(inputStream);
                    return bitmap;
                }
            } catch (Exception e) {
                urlConnection.disconnect();
                Log.w("ImageDownloader", "Error downloading image from " + url);
            } finally {
                if (urlConnection != null) {
                    urlConnection.disconnect();
                }
            }
            return null;
        }
    }
}
