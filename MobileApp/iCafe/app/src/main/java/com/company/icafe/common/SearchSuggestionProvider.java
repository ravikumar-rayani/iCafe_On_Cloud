package com.company.icafe.common;

import android.app.SearchManager;
import android.content.ContentProvider;
import android.content.ContentValues;
import android.content.UriMatcher;
import android.database.Cursor;
import android.database.MatrixCursor;
import android.net.Uri;
import android.provider.BaseColumns;
import android.support.annotation.Nullable;

import com.company.icafe.database.MenuDBHandler;
import com.company.icafe.model.MenuItem;

import java.util.ArrayList;
import java.util.List;
import java.util.Set;

/**
 * Created by pmishra on 16/11/16.
 */

public class SearchSuggestionProvider extends ContentProvider {

    private static final String AUTHORITY = "com.company.icafe.common.searchsuggestionprovider";

    private static final int TYPE_ALL_SUGGESTIONS = 1;
    private static final int TYPE_SINGLE_SUGGESTION = 2;

    private UriMatcher mUriMatcher;
    private List<MenuItem> suggestions;
    private Set<String> tags;

    @Override
    public boolean onCreate() {
        mUriMatcher = new UriMatcher(UriMatcher.NO_MATCH);
        mUriMatcher.addURI(AUTHORITY, "/#", TYPE_SINGLE_SUGGESTION);
        mUriMatcher.addURI(AUTHORITY, "search_suggest_query/*", TYPE_ALL_SUGGESTIONS);
        return false;
    }

    @Nullable
    @Override
    public Cursor query(Uri uri, String[] strings, String s, String[] strings1, String s1) {
        if(suggestions == null || suggestions.isEmpty()){
            ArrayList<MenuItem> menuItems = MenuDBHandler.getInstance(getContext()).getAllMenuItems();
            suggestions = new ArrayList<>();
            for (MenuItem menuItem:menuItems) {
                suggestions.add(menuItem);
//                String[] tagValues = menuItem.getTags();
//                for (String tag:tagValues) {
//                    tags.add(tag);
//                }
            }
//            for (String tag:tags) {
//                suggestions.add(tag);
//            }
        }

        MatrixCursor cursor = new MatrixCursor(
                new String[] {
                        BaseColumns._ID,
                        SearchManager.SUGGEST_COLUMN_TEXT_1,
                        SearchManager.SUGGEST_COLUMN_INTENT_DATA_ID,
                        SearchManager.SUGGEST_COLUMN_INTENT_EXTRA_DATA
                }
        );

        if (mUriMatcher.match(uri) == TYPE_ALL_SUGGESTIONS) {
            if (suggestions != null) {
                String query = uri.getLastPathSegment().toUpperCase();
                int limit = Integer.parseInt(uri.getQueryParameter(SearchManager.SUGGEST_PARAMETER_LIMIT));

                int length = suggestions.size();
                for (int i = 0; i < length && cursor.getCount() < limit; i++) {
                    MenuItem menuItem = suggestions.get(i);
                    if (menuItem.getName().toUpperCase().contains(query)) {
                        cursor.addRow(new Object[]{i, menuItem.getName(), i, menuItem.getId()});
                    }
                }
            }
        } else if (mUriMatcher.match(uri) == TYPE_SINGLE_SUGGESTION) {
            int position = Integer.parseInt(uri.getLastPathSegment());
            MenuItem menuItem = suggestions.get(position);
            cursor.addRow(new Object[]{position, menuItem.getName(), position, menuItem.getId()});
        }
        return cursor;
    }

    @Nullable
    @Override
    public String getType(Uri uri) {
        return null;
    }

    @Nullable
    @Override
    public Uri insert(Uri uri, ContentValues contentValues) {
        return null;
    }

    @Override
    public int delete(Uri uri, String s, String[] strings) {
        return 0;
    }

    @Override
    public int update(Uri uri, ContentValues contentValues, String s, String[] strings) {
        return 0;
    }
}
