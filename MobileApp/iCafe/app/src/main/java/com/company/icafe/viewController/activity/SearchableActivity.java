package com.company.icafe.viewController.activity;

import android.app.SearchManager;
import android.content.AsyncQueryHandler;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.provider.BaseColumns;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;

import com.company.icafe.R;
import com.company.icafe.adapter.DigitalMenuListViewAdapter;
import com.company.icafe.database.MenuDBHandler;
import com.company.icafe.model.MenuItem;

import java.lang.ref.WeakReference;
import java.util.ArrayList;

/**
 * Created by pmishra on 16/11/16.
 */

public class SearchableActivity extends AppCompatActivity {

    private MyHandler mHandler;

    private RecyclerView digitalMenuListRecyclerView;

    ArrayList<MenuItem> searchedMenuItems = new ArrayList<MenuItem>();
    ArrayList<MenuItem> allMenuItems;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_searchable);
        digitalMenuListRecyclerView = (RecyclerView) findViewById(R.id.searchedItemsListRecyclerView);
        digitalMenuListRecyclerView.setLayoutManager(new LinearLayoutManager(this));
        digitalMenuListRecyclerView.setHasFixedSize(true);

        allMenuItems = MenuDBHandler.getInstance(this).getAllMenuItems();
        Intent intent = getIntent();
        if (Intent.ACTION_SEARCH.equals(intent.getAction())) {
            String query = intent.getStringExtra(SearchManager.QUERY);

        } else if (Intent.ACTION_VIEW.equals(intent.getAction())) {
            mHandler = new MyHandler(this);
            mHandler.startQuery(0, null, intent.getData(), null, null, null, null);
        }
    }

    class MyHandler extends AsyncQueryHandler {
        // avoid memory leak
        WeakReference<SearchableActivity> activity;

        public MyHandler(SearchableActivity searchableActivity) {
            super(searchableActivity.getContentResolver());
            activity = new WeakReference<>(searchableActivity);
        }

        @Override
        protected void onQueryComplete(int token, Object cookie, Cursor cursor) {
            super.onQueryComplete(token, cookie, cursor);
            if (cursor == null || cursor.getCount() == 0) return;

            cursor.moveToFirst();

            long id = cursor.getLong(cursor.getColumnIndex(BaseColumns._ID));
            String meuItemName = cursor.getString(cursor.getColumnIndex(SearchManager.SUGGEST_COLUMN_TEXT_1));
            int menuItemID = cursor.getInt(cursor.getColumnIndex(SearchManager.SUGGEST_COLUMN_INTENT_EXTRA_DATA));

            for (MenuItem menuItem:allMenuItems) {
                if(menuItem.getId() == menuItemID)
                    searchedMenuItems.add(menuItem);
            }
            cursor.close();

            if (activity.get() != null) {

//                if(searchedMenuItems != null && !searchedMenuItems.isEmpty())
//                    digitalMenuListRecyclerView.setAdapter(new DigitalMenuListViewAdapter(getApplicationContext(), searchedMenuItems));
            }
        }
    };
}
