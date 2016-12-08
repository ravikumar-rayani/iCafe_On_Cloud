package com.company.icafe.adapter;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;

import com.company.icafe.model.CategoryItem;
import com.company.icafe.model.MenuItem;
import com.company.icafe.viewController.fragment.DigitalMenuRecycleViewFragment;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.Map;

/**
 * Created by pmishra on 02/08/16.
 */

public class DigitalMenuViewPagerAdapter extends FragmentStatePagerAdapter {

    LinkedHashMap<CategoryItem, ArrayList<MenuItem>> categoryItemArrayListMap;

    public DigitalMenuViewPagerAdapter(FragmentManager fm, LinkedHashMap<CategoryItem, ArrayList<MenuItem>> categoryItemArrayListMap) {
        super(fm);
        this.categoryItemArrayListMap = categoryItemArrayListMap;
    }

    @Override
    public Fragment getItem(int position) {

        DigitalMenuRecycleViewFragment digitalMenuRecycleViewFragment = new DigitalMenuRecycleViewFragment();
        digitalMenuRecycleViewFragment.menuItemArrayList = getValueFromCategoryMap(position);
        return digitalMenuRecycleViewFragment;
    }

    @Override
    public int getCount() {
        return categoryItemArrayListMap.size();
    }

    @Override
    public CharSequence getPageTitle(int position) {
        return getKeyFromCategoryMap(position).getName();
    }

    private ArrayList<MenuItem> getValueFromCategoryMap(int id){
        Iterator iterator = categoryItemArrayListMap.entrySet().iterator();
        int n = 0;
        while(iterator.hasNext()){
            Map.Entry<CategoryItem, ArrayList<MenuItem>> entry = (Map.Entry<CategoryItem, ArrayList<MenuItem>>) iterator.next();
            if(n == id){
                return entry.getValue();
            }
            n ++;
        }
        return null;
    }

    private CategoryItem getKeyFromCategoryMap(int id){
        Iterator iterator = categoryItemArrayListMap.entrySet().iterator();
        int n = 0;
        while(iterator.hasNext()){
            Map.Entry<CategoryItem, ArrayList<MenuItem>> entry = (Map.Entry<CategoryItem, ArrayList<MenuItem>>) iterator.next();
            if(n == id){
                return entry.getKey();
            }
            n ++;
        }
        return null;
    }
}
