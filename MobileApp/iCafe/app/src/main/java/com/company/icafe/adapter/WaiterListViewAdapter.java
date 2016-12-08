package com.company.icafe.adapter;

import android.content.Context;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.company.icafe.R;
import com.company.icafe.model.Table;

import java.util.List;

/**
 * Created by pmishra on 11/10/16.
 */

public class WaiterListViewAdapter extends RecyclerView.Adapter<WaiterListViewAdapter.ListViewHolder>  {

    private List<Table> mTables;
    private Context mContext;

    public WaiterListViewAdapter(Context context, List<Table> items) {
        mContext = context;
        mTables = items;
    }

    @Override
    public WaiterListViewAdapter.ListViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.waiter_table_item_layout, parent, false);
        return new WaiterListViewAdapter.ListViewHolder(view);
    }

    @Override
    public void onBindViewHolder(WaiterListViewAdapter.ListViewHolder holder, int position) {

        final Table table = mTables.get(position);
        holder.itemUUID.setText(String.valueOf(table.getId()));
        holder.itemTitle.setText(table.getTableName());

    }

    @Override
    public int getItemCount() {
        return mTables.size();
    }

    public class ListViewHolder extends RecyclerView.ViewHolder {

        public final View mView;
        TextView itemUUID, itemTitle;

        public ListViewHolder(View view) {
            super(view);
            mView = view;

            itemUUID = (TextView) view.findViewById(R.id.tableItemIdTextView);
            itemTitle = (TextView) view.findViewById(R.id.tableItemNameTextView);
        }

        @Override
        public String toString() {
            return super.toString() + " '" + itemTitle.getText();
        }
    }
}
