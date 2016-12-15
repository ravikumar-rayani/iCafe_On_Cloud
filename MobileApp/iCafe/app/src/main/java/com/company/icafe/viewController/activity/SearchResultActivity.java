package com.company.icafe.viewController.activity;

import android.content.Intent;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;

import com.company.icafe.R;
import com.company.icafe.adapter.DigitalMenuListViewAdapter;
import com.company.icafe.database.MenuDBHandler;
import com.company.icafe.model.Constants;
import com.company.icafe.model.MenuItem;

import java.util.ArrayList;

/**
 * Created by pmishra on 16/11/16.
 */

public class SearchResultActivity extends AppCompatActivity {

    private RecyclerView digitalMenuListRecyclerView;

    ArrayList<MenuItem> searchedMenuItems = new ArrayList<MenuItem>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_searchable);
        digitalMenuListRecyclerView = (RecyclerView) findViewById(R.id.searchedItemsListRecyclerView);
        digitalMenuListRecyclerView.setLayoutManager(new LinearLayoutManager(this));
        digitalMenuListRecyclerView.setHasFixedSize(true);

        Intent intent = getIntent();
        String searchQuery = intent.getStringExtra(Constants.SEARCH_INTENT_TAG);

        searchedMenuItems = MenuDBHandler.getInstance(getApplicationContext()).searchMenuItems(searchQuery);
        if(searchedMenuItems != null && !searchedMenuItems.isEmpty())
            digitalMenuListRecyclerView.setAdapter(new DigitalMenuListViewAdapter(getApplicationContext(), searchedMenuItems, null));

    }
}
