package com.company.icafe.adapter;

import android.content.Context;
import android.content.Intent;
import android.graphics.Typeface;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.TextView;

import com.company.icafe.R;
import com.company.icafe.model.SubOrder;
import com.company.icafe.model.SubOrderItem;
import com.company.icafe.viewController.activity.MenuItemInfoActivity;


/**
 * Created by 20105480 on 30-08-2016.
 */
public class SubOrderExpandableListAdapter extends BaseExpandableListAdapter {

    private Context mContext;
    private SubOrder[] subOrders;

    public static SubOrderExpandableListAdapter newInstance(Context context, SubOrder[] subOrders) {
        SubOrderExpandableListAdapter subOrderExpandableListAdapter;
        subOrderExpandableListAdapter = new SubOrderExpandableListAdapter(context, subOrders);
        return subOrderExpandableListAdapter;
    }

    public SubOrderExpandableListAdapter(Context context, SubOrder[] subOrders) {
        this.mContext = context;
        this.subOrders = subOrders;
    }

    @Override
    public int getGroupCount() {
        return subOrders.length;
    }

    @Override
    public int getChildrenCount(int groupPosition) {
        return subOrders[groupPosition].getSubOrderItems().length;
    }

    @Override
    public Object getGroup(int groupPosition) {
        return subOrders[groupPosition];
    }

    @Override
    public Object getChild(int groupPosition, int childPosition) {
        return subOrders[groupPosition].getSubOrderItems()[childPosition];
    }

    @Override
    public long getGroupId(int groupPosition) {
        return groupPosition;
    }

    @Override
    public long getChildId(int groupPosition, int childPosition) {
        return childPosition;
    }

    @Override
    public boolean hasStableIds() {
        return false;
    }

    @Override
    public View getGroupView(int groupPosition, boolean isExpanded, View convertView, ViewGroup parent) {
        SubOrder subOrder = (SubOrder) getGroup(groupPosition);
        if (convertView == null) {
            LayoutInflater infalInflater = (LayoutInflater) mContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = infalInflater.inflate(R.layout.sub_order_group_row_layout, null);
        }
        TextView item = (TextView) convertView.findViewById(R.id.subOrderIdTextView);
        item.setTypeface(null, Typeface.BOLD);
        item.setText(subOrder.getSubOrderId());

        return convertView;
    }

    @Override
    public View getChildView(int groupPosition, int childPosition, boolean isLastChild, View convertView, ViewGroup parent) {
        final SubOrderItem subOrderItem = (SubOrderItem) getChild(groupPosition, childPosition);
        if (convertView == null) {
            LayoutInflater infalInflater = (LayoutInflater) mContext.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
            convertView = infalInflater.inflate(R.layout.sub_order_item_row_layout, null);

            convertView.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    Intent intent = new Intent(mContext.getApplicationContext(), MenuItemInfoActivity.class);
                    mContext.startActivity(intent);
                }
            });
        }

        TextView itemNameTextView = (TextView) convertView.findViewById(R.id.subOrderItemNameTextView);
        itemNameTextView.setText(subOrderItem.getItemName());

        TextView quantityTextView = (TextView) convertView.findViewById(R.id.subOrderItemQuantityTextView);
        quantityTextView.setText(String.valueOf(subOrderItem.getItemQuantity()));
        return convertView;
    }

    @Override
    public boolean isChildSelectable(int groupPosition, int childPosition) {
        return true;
    }
}
