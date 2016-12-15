package com.company.icafe.viewController.activity;

import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.view.ViewPager;
import android.support.v7.app.AppCompatActivity;

import com.company.icafe.R;
import com.company.icafe.adapter.OrderStatusViewPagerAdapter;
import com.company.icafe.database.OrderDBHandler;
import com.company.icafe.model.Order;

import java.util.ArrayList;

/**
 * Created by pmishra on 20/11/16.
 */

public class OrderStatusActivity extends AppCompatActivity {


    private TabLayout orderStatusTabLayout;
    private ViewPager orderStatusViewPager;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.running_order_layout);

        ArrayList<Order> orderArrayList = OrderDBHandler.getInstance(getApplicationContext()).getOrdersListWithContent();

        orderStatusViewPager = (ViewPager) findViewById(R.id.order_status_viewpager);
        orderStatusViewPager.setFitsSystemWindows(true);

        orderStatusTabLayout = (TabLayout) findViewById(R.id.order_status_tabs);

        orderStatusViewPager.addOnPageChangeListener(new TabLayout.TabLayoutOnPageChangeListener(orderStatusTabLayout));
        orderStatusTabLayout.setOnTabSelectedListener(onTabSelectedListener(orderStatusViewPager));

        OrderStatusViewPagerAdapter orderStatusViewPagerAdapter = new OrderStatusViewPagerAdapter(getSupportFragmentManager(), orderArrayList);
        orderStatusViewPager.setAdapter(orderStatusViewPagerAdapter);
        orderStatusTabLayout.setupWithViewPager(orderStatusViewPager);

    }

    private TabLayout.OnTabSelectedListener onTabSelectedListener(final ViewPager pager) {
        return new TabLayout.OnTabSelectedListener() {
            @Override
            public void onTabSelected(TabLayout.Tab tab) {
                pager.setCurrentItem(tab.getPosition());
            }

            @Override
            public void onTabUnselected(TabLayout.Tab tab) {

            }

            @Override
            public void onTabReselected(TabLayout.Tab tab) {

            }
        };
    }
}
