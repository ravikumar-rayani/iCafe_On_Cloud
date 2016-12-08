package com.company.icafe.viewController.fragment;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.company.icafe.R;
import com.company.icafe.adapter.WaiterListViewAdapter;
import com.company.icafe.database.TableDBHandler;
import com.company.icafe.model.Table;
import com.company.icafe.ui.control.MarginDecoration;

import java.util.ArrayList;

/**
 * Created by pmishra on 03/10/16.
 */

public class WaiterHomeFragment extends Fragment {

    private WaiterListViewAdapter waiterListViewAdapter;
    @Override
    public void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        super.onCreateView(inflater, container, savedInstanceState);

        View view = (View) inflater.inflate(R.layout.waiter_home_layout, container, false);

        setHasOptionsMenu(true);

        RecyclerView tableListRecyclerView = (RecyclerView) view.findViewById(R.id.tableListRecyclerView);

//        tableListRecyclerView.setLayoutManager(new MarginDecoration(getActivity()));
        tableListRecyclerView.addItemDecoration(new MarginDecoration(getActivity()));
        tableListRecyclerView.setHasFixedSize(true);

        ArrayList<Table> mTableList = TableDBHandler.getInstance(getContext()).getAllTableItems();
        if(waiterListViewAdapter == null && !mTableList.isEmpty())
            waiterListViewAdapter = new WaiterListViewAdapter(getContext(), mTableList);

        tableListRecyclerView.setAdapter(waiterListViewAdapter);
        waiterListViewAdapter.notifyDataSetChanged();
        return view;
    }
}
