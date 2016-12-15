package com.company.icafe.adapter;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;

import com.company.icafe.model.Order;
import com.company.icafe.viewController.fragment.OrderViewFragment;

import java.util.ArrayList;

/**
 * Created by pmishra on 20/11/16.
 */

public class OrderStatusViewPagerAdapter extends FragmentStatePagerAdapter {

    private final String LOG_TAG = OrderStatusViewPagerAdapter.class.getSimpleName();

    ArrayList<Order> runningOrderArrayList;

    public OrderStatusViewPagerAdapter(FragmentManager fm, ArrayList<Order> runningOrderArrayList) {
        super(fm);
        this.runningOrderArrayList = runningOrderArrayList;
    }

    @Override
    public Fragment getItem(int position) {
        OrderViewFragment orderViewFragment = OrderViewFragment.newInstance();
        orderViewFragment.setOrder(runningOrderArrayList.get(position));
        return orderViewFragment;
    }

    @Override
    public int getCount() {
        return runningOrderArrayList.size();
    }

    @Override
    public CharSequence getPageTitle(int position) {
        String title = "Order ID\n"+ runningOrderArrayList.get(position).getOrderId();
        return title;
    }
}
