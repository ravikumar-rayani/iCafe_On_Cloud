package com.company.icafe.viewController.fragment;

import android.app.Dialog;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ExpandableListView;
import android.widget.TextView;

import com.company.icafe.R;
import com.company.icafe.adapter.SubOrderExpandableListAdapter;
import com.company.icafe.model.Order;

/**
 * Created by 20105480 on 26-08-2016.
 */
public class OrderViewFragment extends Fragment {

    public static final String TAG = OrderViewFragment.class
            .getSimpleName();

    private static OrderViewFragment orderViewFragment;

    private Dialog orderViewDialog;
    private Order orderItem;

    public static OrderViewFragment newInstance() {
        orderViewFragment = new OrderViewFragment();
        return new OrderViewFragment();
    }

    public void setOrder(Order order){
        this.orderItem = order;
    }

    public OrderViewFragment() {
    }

    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        super.onCreateView(inflater, container, savedInstanceState);

        View view = (View) inflater.inflate(R.layout.running_order_view_layout, container, false);

        TextView orderIdTextView = (TextView) view.findViewById(R.id.orderIdTextView);
        TextView customerIdTextView = (TextView) view.findViewById(R.id.customerIdTextView);
        ExpandableListView subOrderExpandableListView = (ExpandableListView) view.findViewById(R.id.subOrderItemsExpandableListView);

        orderIdTextView.setText(String.valueOf(orderItem.getOrderId()));
        customerIdTextView.setText(orderItem.getCustomerId());
        subOrderExpandableListView.setAdapter(SubOrderExpandableListAdapter.newInstance(getActivity(), orderItem.getSubOrders()));
        return view;
    }
}
