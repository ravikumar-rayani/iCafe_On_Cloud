package com.company.icafe.callback;

import com.company.icafe.model.CategoryItem;
import com.company.icafe.model.MenuItem;

import java.util.ArrayList;
import java.util.LinkedHashMap;

/**
 * Created by pmishra on 28/09/16.
 */

public interface CategoryItemActionListener {

    public void addCategoryDataItem(CategoryItem categoryItem);

    public void addCategoryDataItemList(ArrayList<CategoryItem> categoryItemList);

    public ArrayList<CategoryItem> getAllCategoryItems();

    public int getCategoryItemCount();

    public LinkedHashMap<CategoryItem, ArrayList<MenuItem>> getCategoryItemsWithMenuItems();
}
