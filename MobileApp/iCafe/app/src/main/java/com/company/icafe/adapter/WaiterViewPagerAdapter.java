package com.company.icafe.adapter;

import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentStatePagerAdapter;
import android.view.ViewGroup;

import com.company.icafe.viewController.fragment.WaiterHomeFragment;

/**
 * Created by pmishra on 11/10/16.
 */

public class WaiterViewPagerAdapter extends FragmentStatePagerAdapter {

    public WaiterViewPagerAdapter(FragmentManager fm) {
        super(fm);
    }

    @Override
    public Fragment getItem(int position) {
        return new WaiterHomeFragment();
    }

    @Override
    public int getCount() {
        return 1;
    }

    @Override
    public CharSequence getPageTitle(int position) {
        super.getPageTitle(position);
        return "Waiter Name";
    }

    @Override
    public Object instantiateItem(ViewGroup container, int position) {
        return super.instantiateItem(container, position);
    }
}
