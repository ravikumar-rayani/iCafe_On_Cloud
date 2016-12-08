package com.company.icafe.callback;

import com.company.icafe.model.MenuItem;

import java.util.ArrayList;

/**
 * Created by pmishra on 21/08/16.
 */

public interface MenuItemActionListener {

    public void addMenuDataItem(MenuItem menuItem);

    public void addMenuDataItemList(ArrayList<MenuItem> menuItemList);

    public ArrayList<MenuItem> getAllMenuItems();

    public int getMenuItemCount();

    public ArrayList<MenuItem> getMenuItemsFromCategory(int categoryId);
}
