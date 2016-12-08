package com.company.icafe.viewController.fragment;

import android.app.Dialog;
import android.app.SearchManager;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v4.view.MenuItemCompat;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.support.v7.widget.SearchView;
import android.support.v7.widget.Toolbar;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.WindowManager;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.TextView;

import com.company.icafe.R;
import com.company.icafe.adapter.DigitalMenuGridViewAdapter;
import com.company.icafe.adapter.DigitalMenuListViewAdapter;
import com.company.icafe.adapter.SearchAdapter;
import com.company.icafe.callback.CartItemsUpdated;
import com.company.icafe.common.SharedPreference;
import com.company.icafe.database.CartDBHandler;
import com.company.icafe.database.MenuDBHandler;
import com.company.icafe.model.Constants;
import com.company.icafe.model.MenuItem;
import com.company.icafe.ui.control.MarginDecoration;
import com.company.icafe.viewController.activity.AppHomeActivity;
import com.company.icafe.viewController.activity.CartActivity;
import com.company.icafe.viewController.activity.OrderStatusActivity;
import com.company.icafe.viewController.activity.SearchableActivity;

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

        // Provide functionality for search menu button action
//        android.view.MenuItem searchItem = menu.findItem(R.id.action_search_menu);
//        SearchView searchView = (SearchView) MenuItemCompat.getActionView(searchItem);
//        searchView.setOnQueryTextListener(new SearchView.OnQueryTextListener() {
//            @Override
//            public boolean onQueryTextSubmit(String query) {
//                // User pressed the search button
//                return false;
//            }
//
//            @Override
//            public boolean onQueryTextChange(String newText) {
//                // User changed the text
//                return false;
//            }
//        });
//
//        SearchManager searchManager = (SearchManager) getActivity().getSystemService(Context.SEARCH_SERVICE);
//        searchView.setSearchableInfo(searchManager.getSearchableInfo(
//                new ComponentName(getActivity(), SearchableActivity.class)));
//        searchView.setIconifiedByDefault(false);
//
//        MenuItemCompat.setOnActionExpandListener(searchItem, new MenuItemCompat.OnActionExpandListener() {
//            @Override
//            public boolean onMenuItemActionExpand(android.view.MenuItem item) {
//                return true;
//            }
//
//            @Override
//            public boolean onMenuItemActionCollapse(android.view.MenuItem item) {
//                return true;
//            }
//        });
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
            case R.id.action_search_menu:
                loadToolBarSearch();
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


    public void loadToolBarSearch() {
        ArrayList<String> menuItemsStored = SharedPreference.loadList(getActivity(), Constants.PREFS_NAME, Constants.KEY_MENU_ITEMS);

        View view = getActivity().getLayoutInflater().inflate(R.layout.view_toolbar_search, null);
        LinearLayout parentToolbarSearch = (LinearLayout) view.findViewById(R.id.parent_toolbar_search);
        ImageView imgToolBack = (ImageView) view.findViewById(R.id.img_tool_back);
        final EditText edtToolSearch = (EditText) view.findViewById(R.id.edt_tool_search);
        final ListView listSearch = (ListView) view.findViewById(R.id.list_search);
        final TextView txtEmpty = (TextView) view.findViewById(R.id.txt_empty);

        setListViewHeightBasedOnChildren(listSearch);

        edtToolSearch.setHint("Search your country");

        final Dialog toolbarSearchDialog = new Dialog(getActivity(), R.style.MaterialSearch);
        toolbarSearchDialog.setContentView(view);
        toolbarSearchDialog.setCancelable(false);
        toolbarSearchDialog.getWindow().setLayout(LinearLayout.LayoutParams.MATCH_PARENT, LinearLayout.LayoutParams.MATCH_PARENT);
        toolbarSearchDialog.getWindow().setGravity(Gravity.BOTTOM);
        toolbarSearchDialog.show();

        toolbarSearchDialog.getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_VISIBLE);

        menuItemsStored = (menuItemsStored != null && menuItemsStored.size() > 0) ? menuItemsStored : new ArrayList<String>();
        final SearchAdapter searchAdapter = new SearchAdapter(getActivity(), menuItemsStored, false);

        listSearch.setVisibility(View.VISIBLE);
        listSearch.setAdapter(searchAdapter);


        listSearch.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int position, long l) {

                String country = String.valueOf(adapterView.getItemAtPosition(position));
                SharedPreference.addList(getActivity(), Constants.PREFS_NAME, Constants.KEY_MENU_ITEMS, country);
                edtToolSearch.setText(country);
                listSearch.setVisibility(View.GONE);


            }
        });
        edtToolSearch.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {

                searchSuggestionsList = getSearchSuggestionList();
                listSearch.setVisibility(View.VISIBLE);
                searchAdapter.updateList(getSearchSuggestionList(), true);
            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                ArrayList<String> filterList = new ArrayList<String>();
                boolean isNodata = false;
                if (s.length() > 0) {
                    for (int i = 0; i < searchSuggestionsList.size(); i++) {


                        if (searchSuggestionsList.get(i).toLowerCase().startsWith(s.toString().trim().toLowerCase())) {

                            filterList.add(searchSuggestionsList.get(i));

                            listSearch.setVisibility(View.VISIBLE);
                            searchAdapter.updateList(filterList, true);
                            isNodata = true;
                        }
                    }
                    if (!isNodata) {
                        listSearch.setVisibility(View.GONE);
                        txtEmpty.setVisibility(View.VISIBLE);
                        txtEmpty.setText("No data found");
                    }
                } else {
                    listSearch.setVisibility(View.GONE);
                    txtEmpty.setVisibility(View.GONE);
                }

            }

            @Override
            public void afterTextChanged(Editable s) {

            }
        });

        imgToolBack.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                toolbarSearchDialog.dismiss();
            }
        });
    }

    private void setListViewHeightBasedOnChildren(ListView listView) {
        ListAdapter listAdapter = listView.getAdapter();
        if (listAdapter == null) {
            // pre-condition
            return;
        }

        int totalHeight = 0;
        for (int i = 0; i < listAdapter.getCount(); i++) {
            View listItem = listAdapter.getView(i, null, listView);
            listItem.measure(0, 0);
            totalHeight += listItem.getMeasuredHeight();
        }

        ViewGroup.LayoutParams params = listView.getLayoutParams();
        params.height = totalHeight + (listView.getDividerHeight() * (listAdapter.getCount() - 1));
        listView.setLayoutParams(params);
        listView.requestLayout();
    }

    private ArrayList<String> getSearchSuggestionList(){
        ArrayList<MenuItem> menuItems = MenuDBHandler.getInstance(getContext()).getAllMenuItems();
        ArrayList<String> suggestions = new ArrayList<>();
        for (MenuItem menuItem:menuItems) {
            suggestions.add(menuItem.getName());
//                String[] tagValues = menuItem.getTags();
//                for (String tag:tagValues) {
//                    tags.add(tag);
//                }
        }
//            for (String tag:tags) {
//                suggestions.add(tag);
//            }
        return suggestions;
    }

}
