package com.company.icafe.viewController.fragment;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v4.view.MenuItemCompat;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.company.icafe.R;
import com.company.icafe.adapter.DigitalMenuGridViewAdapter;
import com.company.icafe.adapter.DigitalMenuListViewAdapter;
import com.company.icafe.callback.CartItemsUpdated;
import com.company.icafe.database.CartDBHandler;
import com.company.icafe.model.Constants;
import com.company.icafe.model.MenuItem;
import com.company.icafe.ui.control.MarginDecoration;
import com.company.icafe.viewController.activity.AppHomeActivity;
import com.company.icafe.viewController.activity.CartActivity;
import com.company.icafe.viewController.activity.OrderStatusActivity;

import java.util.ArrayList;

/**
 * Created by pmishra on 07/08/16.
 */

public class DigitalMenuRecycleViewFragment extends Fragment implements Toolbar.OnMenuItemClickListener, CartItemsUpdated {

    private String TAG = DigitalMenuRecycleViewFragment.class.getSimpleName();
    public ArrayList<MenuItem> menuItemArrayList;
    private RecyclerView digitalMenuGridRecyclerView, digitalMenuListRecyclerView;
    private android.view.MenuItem changeViewMenuItem;
    private TextView cartBubbleTextView;
    private ArrayList<String> searchSuggestionsList;

    public DigitalMenuRecycleViewFragment() { }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        super.onCreateView(inflater, container, savedInstanceState);

        View view = (View) inflater.inflate(R.layout.digital_menu_recycler_view, container, false);

        setHasOptionsMenu(true);

        digitalMenuGridRecyclerView = (RecyclerView) view.findViewById(R.id.gridRecyclerView);
        digitalMenuGridRecyclerView.addItemDecoration(new MarginDecoration(getActivity()));
        digitalMenuGridRecyclerView.setHasFixedSize(true);
        if(menuItemArrayList != null && !menuItemArrayList.isEmpty())
            digitalMenuGridRecyclerView.setAdapter(new DigitalMenuGridViewAdapter(getActivity(), menuItemArrayList, this));
        digitalMenuGridRecyclerView.setVisibility(View.VISIBLE);

        digitalMenuListRecyclerView = (RecyclerView) view.findViewById(R.id.listRecyclerView);
        digitalMenuListRecyclerView.setLayoutManager(new LinearLayoutManager(getActivity()));
        digitalMenuListRecyclerView.setHasFixedSize(true);
        if(menuItemArrayList != null && !menuItemArrayList.isEmpty())
            digitalMenuListRecyclerView.setAdapter(new DigitalMenuListViewAdapter(getActivity(), menuItemArrayList, this));
        digitalMenuListRecyclerView.setVisibility(View.INVISIBLE);

        switchView();
        return view;
    }

    @Override
    public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {
        super.onCreateOptionsMenu(menu, inflater);

        getActivity().getMenuInflater().inflate(R.menu.action_bar_menu, menu);

        android.view.MenuItem addCartMenuItem = menu.findItem(R.id.action_add_cart);
        android.view.MenuItem orderStatusMenuItem = menu.findItem(R.id.action_order_status);
        changeViewMenuItem = menu.findItem(R.id.action_view_menu);

        switch (AppHomeActivity.menuMode) {
            case Constants.DIGITAL_MENU_MODE:
                addCartMenuItem.setVisible(false);
                orderStatusMenuItem.setVisible(false);
                break;
            case Constants.TABLE_USER_MODE:
                addCartMenuItem.setVisible(true);
                orderStatusMenuItem.setVisible(true);
                break;
            case Constants.WAITER_USER_MODE:

                break;
        }

        // Bubble to show number of items added in cart
        cartBubbleTextView = (TextView) addCartMenuItem.getActionView().findViewById(R.id.action_add_cart_text_view);
        cartItemsUpdated();

        // Provide action for Cart menu Item
        final android.view.MenuItem addCartMenuBubbleItem = menu.getItem(3);
        if (addCartMenuBubbleItem.getItemId() == R.id.action_add_cart) {
            View view = MenuItemCompat.getActionView(addCartMenuBubbleItem);
            if (view != null) {
                view.setOnClickListener(new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        launchCartActivity();
                    }
                });
            }
        }
    }

    @Override
    public boolean onOptionsItemSelected(android.view.MenuItem item) {
        super.onOptionsItemSelected(item);

        switch (item.getItemId()){

            case R.id.action_view_menu:
                switchView();
                break;
            case  R.id.action_order_status:
                launchOrderStatusActivity();
                break;
        }

        return true;
    }

    @Override
    public boolean onMenuItemClick(android.view.MenuItem item) {
        return false;
    }

    private void switchView() {
        if(AppHomeActivity.currentViewMode == Constants.GRID_VIEW_MODE) {
            AppHomeActivity.currentViewMode = Constants.LIST_VIEW_MODE;
            if(changeViewMenuItem != null) {
                changeViewMenuItem.setIcon(R.drawable.action_grid_view);
                changeViewMenuItem.setTitle(getString(R.string.action_grid_view));
            }
            digitalMenuListRecyclerView.setVisibility(View.VISIBLE);
            digitalMenuGridRecyclerView.setVisibility(View.INVISIBLE);
        } else if(AppHomeActivity.currentViewMode == Constants.LIST_VIEW_MODE) {
            AppHomeActivity.currentViewMode = Constants.GRID_VIEW_MODE;
            if(changeViewMenuItem != null) {
                changeViewMenuItem.setIcon(R.drawable.action_list_view);
                changeViewMenuItem.setTitle(getString(R.string.action_list_view));
            }
            digitalMenuListRecyclerView.setVisibility(View.INVISIBLE);
            digitalMenuGridRecyclerView.setVisibility(View.VISIBLE);
        }
    }

    @Override
    public void cartItemsUpdated() {
        if(cartBubbleTextView != null)
            cartBubbleTextView.setText(String.valueOf(CartDBHandler.getInstance(getActivity()).getCartItemsCount()));
    }

    private void launchOrderStatusActivity() {
        Intent orderStatusActivityIntent = new Intent(getActivity(), OrderStatusActivity.class);
        startActivity(orderStatusActivityIntent);
    }

    private void launchCartActivity() {
        Intent cartActivityIntent = new Intent(getActivity(), CartActivity.class);
        startActivity(cartActivityIntent);
    }
}
