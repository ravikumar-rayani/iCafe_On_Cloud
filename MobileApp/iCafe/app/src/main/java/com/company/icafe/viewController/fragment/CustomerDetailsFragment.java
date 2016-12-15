package com.company.icafe.viewController.fragment;

import android.app.Dialog;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.DialogFragment;
import android.support.v7.widget.Toolbar;
import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;

import com.company.icafe.R;

/**
 * Created by pmishra on 12/11/16.
 */

public class CustomerDetailsFragment extends DialogFragment {

    public static final String TAG = CustomerDetailsFragment.class
            .getSimpleName();
    private Dialog customerDetailsFragmentDialog;

    public static CustomerDetailsFragment newInstance() {
        return new CustomerDetailsFragment();
    }

    public CustomerDetailsFragment() {
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.customer_info_edit_layout, container, false);

        // set the listener for Navigation
        Toolbar actionBar = (Toolbar) view.findViewById(R.id.customerDetailsLayoutToolBar);
        if (actionBar!=null) {
            actionBar.inflateMenu(R.menu.action_bar_close);
            actionBar.setTitle("Register Customer");
            actionBar.setOnMenuItemClickListener(new Toolbar.OnMenuItemClickListener() {
                @Override
                public boolean onMenuItemClick(MenuItem item) {
                    switch (item.getItemId()) {
                        case R.id.action_close_menu:
                            getDialog().dismiss();
                            break;
                        default:
                            break;
                    }
                    return true;
                }
            });
        }
        return view;
    }

    @Override
    public void onStart() {
        super.onStart();
        customerDetailsFragmentDialog = getDialog();
        if (customerDetailsFragmentDialog != null)
        {
            int width = ViewGroup.LayoutParams.MATCH_PARENT;
            int height = ViewGroup.LayoutParams.WRAP_CONTENT;
            customerDetailsFragmentDialog.getWindow().setLayout(width, height);
            customerDetailsFragmentDialog.setCancelable(false);
        }
    }
}
