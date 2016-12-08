package com.company.icafe.database;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.company.icafe.callback.CategoryItemActionListener;
import com.company.icafe.callback.MenuItemActionListener;
import com.company.icafe.model.CategoryItem;
import com.company.icafe.model.Constants;
import com.company.icafe.model.MenuItem;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashMap;

/**
 * Created by pmishra on 28/09/16.
 */

public class MenuDBHandler extends DBHandler implements CategoryItemActionListener, MenuItemActionListener {

    private final String LOG_TAG = MenuDBHandler.class.getSimpleName();

    private static MenuDBHandler menuDBHandler;

    public static MenuDBHandler getInstance(Context context){
        if(menuDBHandler == null)
            menuDBHandler = new MenuDBHandler(context);
        return menuDBHandler;
    }

    private MenuDBHandler(Context context) {
        super(context);
    }

    @Override
    public void addMenuDataItem(MenuItem menuItem) {
        SQLiteDatabase db = this.getWritableDatabase();
        addMenuItemIntoDatabase(menuItem, db);
        db.close();
    }

    @Override
    public void addMenuDataItemList(ArrayList<MenuItem> menuItemList) {
        SQLiteDatabase db = this.getWritableDatabase();
        for (MenuItem menuItem: menuItemList) {
            addMenuItemIntoDatabase(menuItem, db);
        }
        db.close();
    }

    private void addMenuItemIntoDatabase(MenuItem menuItem, SQLiteDatabase sqLiteDatabase){
        try{
            ContentValues values = new ContentValues();
            values.put(DBConstants.MENU_ITEM_ID, menuItem.getId());
            values.put(DBConstants.MENU_ITEM_NAME, menuItem.getName());
            values.put(DBConstants.MENU_ITEM_CATEGORY_ID, menuItem.getItemCategoryId());
            values.put(DBConstants.MENU_ITEM_IS_AVAILABLE, menuItem.isAvailable());
            values.put(DBConstants.MENU_ITEM_PRICE, menuItem.getPrice());
            values.put(DBConstants.MENU_ITEM_SPICY_LEVEL, menuItem.getSpicyLevel());
            values.put(DBConstants.MENU_ITEM_INGREDIENTS, Arrays.toString(menuItem.getIngredients()));
            values.put(DBConstants.MENU_ITEM_DESCRIPTION, menuItem.getDescription());
            values.put(DBConstants.MENU_ITEM_TAGS, Arrays.toString(menuItem.getTags()));
            values.put(DBConstants.MENU_ITEM_THUMBNAIL_URL, menuItem.getPicture());
            values.put(DBConstants.MENU_ITEM_IMAGE_URL, menuItem.getFullpicture());

            sqLiteDatabase.insert(DBConstants.MENU_ITEM_TABLE_NAME, null, values);
        }catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" addMenuItemIntoDatabase "  + e.getMessage());
        }
    }

    @Override
    public ArrayList<MenuItem> getAllMenuItems() {
        SQLiteDatabase db = this.getReadableDatabase();
        ArrayList<MenuItem> menuItemList = null;
        try{
            menuItemList = new ArrayList<MenuItem>();
            Cursor cursor = db.rawQuery(DBQuery.constructSelectAllTableQuery(DBConstants.MENU_ITEM_TABLE_NAME), null);
            if(!cursor.isLast())
            {
                while (cursor.moveToNext())
                {
                    MenuItem menuItem = new MenuItem();
                    menuItem.setId(cursor.getInt(cursor.getColumnIndex(DBConstants.MENU_ITEM_ID)));
                    menuItem.setName(cursor.getString(cursor.getColumnIndex(DBConstants.MENU_ITEM_NAME)));
                    menuItem.setItemCategoryId(cursor.getInt(cursor.getColumnIndex(DBConstants.MENU_ITEM_CATEGORY_ID)));
                    if(cursor.getInt(cursor.getColumnIndex(DBConstants.MENU_ITEM_IS_AVAILABLE)) == 0)
                        menuItem.setAvailable(false);
                    else
                        menuItem.setAvailable(true);
                    menuItem.setPrice(cursor.getInt(cursor.getColumnIndex(DBConstants.MENU_ITEM_PRICE)));
                    menuItem.setSpicyLevel(cursor.getInt(cursor.getColumnIndex(DBConstants.MENU_ITEM_SPICY_LEVEL)));
                    menuItem.setIngredients(convertStringToStringArray(cursor.getString(cursor.getColumnIndex(DBConstants.MENU_ITEM_INGREDIENTS))));
                    menuItem.setDescription(cursor.getString(cursor.getColumnIndex(DBConstants.MENU_ITEM_DESCRIPTION)));
                    menuItem.setTags(convertStringToStringArray(cursor.getString(cursor.getColumnIndex(DBConstants.MENU_ITEM_TAGS))));
                    menuItem.setPicture(cursor.getString(cursor.getColumnIndex(DBConstants.MENU_ITEM_THUMBNAIL_URL)));
                    menuItem.setFullpicture(cursor.getString(cursor.getColumnIndex(DBConstants.MENU_ITEM_IMAGE_URL)));

                    menuItemList.add(menuItem);
                }
            }
            db.close();
        }catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" getAllMenuItems "  +e.getMessage());
        } finally {
            db.close();
        }
        return menuItemList;
    }

    public ArrayList<MenuItem> getMenuItemsFromCategory(int categoryId){
        SQLiteDatabase db = this.getReadableDatabase();
        ArrayList<MenuItem> menuItemList = null;
        try{
            menuItemList = new ArrayList<MenuItem>();
            Cursor cursor = db.rawQuery(
                    DBQuery.constructSelectAllTableQuery(
                            DBConstants.MENU_ITEM_TABLE_NAME) +
                            DBConstants.WHERE +
                            DBConstants.MENU_ITEM_CATEGORY_ID +
                            DBConstants.WHERE_EXPERSSION,
                    new String[]{
                            Integer.toString(categoryId)
                    });

//            Cursor cursor = db.rawQuery(DBQuery.constructSelectAllTableQuery(DBConstants.MENU_ITEM_TABLE_NAME), null);
            if(!cursor.isLast())
            {
                while (cursor.moveToNext())
                {
                    MenuItem menuItem = new MenuItem();
                    menuItem.setId(cursor.getInt(cursor.getColumnIndex(DBConstants.MENU_ITEM_ID)));
                    menuItem.setName(cursor.getString(cursor.getColumnIndex(DBConstants.MENU_ITEM_NAME)));
                    menuItem.setItemCategoryId(cursor.getInt(cursor.getColumnIndex(DBConstants.MENU_ITEM_CATEGORY_ID)));
                    if(cursor.getInt(cursor.getColumnIndex(DBConstants.MENU_ITEM_IS_AVAILABLE)) == 0)
                        menuItem.setAvailable(false);
                    else
                        menuItem.setAvailable(true);
                    menuItem.setPrice(cursor.getInt(cursor.getColumnIndex(DBConstants.MENU_ITEM_PRICE)));
                    menuItem.setSpicyLevel(cursor.getInt(cursor.getColumnIndex(DBConstants.MENU_ITEM_SPICY_LEVEL)));
                    menuItem.setIngredients(convertStringToStringArray(cursor.getString(cursor.getColumnIndex(DBConstants.MENU_ITEM_INGREDIENTS))));
                    menuItem.setDescription(cursor.getString(cursor.getColumnIndex(DBConstants.MENU_ITEM_DESCRIPTION)));
                    menuItem.setTags(convertStringToStringArray(cursor.getString(cursor.getColumnIndex(DBConstants.MENU_ITEM_TAGS))));
                    menuItem.setPicture(cursor.getString(cursor.getColumnIndex(DBConstants.MENU_ITEM_THUMBNAIL_URL)));
                    menuItem.setFullpicture(cursor.getString(cursor.getColumnIndex(DBConstants.MENU_ITEM_IMAGE_URL)));

                    menuItemList.add(menuItem);
                }
            }
            db.close();
        }catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" getMenuItemsFromCategory "  +e.getMessage());
        } finally {
            db.close();
        }
        return menuItemList;
    }

    @Override
    public int getMenuItemCount() {
        int num = 0;
        SQLiteDatabase db = this.getReadableDatabase();
        try{
            Cursor cursor = db.rawQuery(DBQuery.constructSelectAllTableQuery(DBConstants.MENU_ITEM_TABLE_NAME), null);
            num = cursor.getCount();
            db.close();
            return num;
        }catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" getMenuItemCount " +e.getMessage());
        } finally {
            db.close();
        }
        return 0;
    }

    private static String[] convertStringToStringArray(String string) {
        if(string == null && string.isEmpty())
            return new String[1];
        String[] strings = string.replace("[", "").replace("]", "").split(", ");
        String result[] = new String[strings.length];
        for (int i = 0; i < result.length; i++) {
            result[i] = strings[i];
        }
        return result;
    }

    @Override
    public void addCategoryDataItem(CategoryItem categoryItem) {
        SQLiteDatabase sqLiteDatabase = this.getWritableDatabase();

        try{
            ContentValues categoryItemTableValues = new ContentValues();

            categoryItemTableValues.put(DBConstants.CATEGORY_ITEM_ID, categoryItem.getId());
            categoryItemTableValues.put(DBConstants.CATEGORY_ITEM_NAME, categoryItem.getName());
            categoryItemTableValues.put(DBConstants.CATEGORY_ITEM_DISCOUNT, categoryItem.getDiscount());
            categoryItemTableValues.put(DBConstants.CATEGORY_ITEM_IS_AVAILABLE, categoryItem.isAvailable());
            categoryItemTableValues.put(DBConstants.CATEGORY_ITEM_IMAGE_URL, categoryItem.getImageUrl());
            categoryItemTableValues.put(DBConstants.CATEGORY_ITEM_DESCRIPTION, categoryItem.getDescription());

            sqLiteDatabase.insert(DBConstants.CATEGORY_ITEM_TABLE, null, categoryItemTableValues);

        } catch (Exception e){
            Log.e(Constants.APP_LOG_TAG, LOG_TAG+" addCategoryDataItemList "  + e.getMessage());
        }
        sqLiteDatabase.close();
    }

    @Override
    public void addCategoryDataItemList(ArrayList<CategoryItem> categoryItemList) {
        for (CategoryItem categoryItem: categoryItemList)
            addCategoryDataItem(categoryItem);
    }

    @Override
    public ArrayList<CategoryItem> getAllCategoryItems() {
        SQLiteDatabase db = this.getReadableDatabase();
        ArrayList<CategoryItem> categoryItemList = null;
        try{
            categoryItemList = new ArrayList<CategoryItem>();
            Cursor cursor = db.rawQuery(DBQuery.constructSelectAllTableQuery(DBConstants.CATEGORY_ITEM_TABLE), null);
            if(!cursor.isLast())
            {
                while (cursor.moveToNext())
                {
                    CategoryItem categoryItem = new CategoryItem();
                    categoryItem.setId(cursor.getInt(cursor.getColumnIndex(DBConstants.CATEGORY_ITEM_ID)));
                    categoryItem.setName(cursor.getString(cursor.getColumnIndex(DBConstants.CATEGORY_ITEM_NAME)));
                    categoryItem.setDiscount(cursor.getInt(cursor.getColumnIndex(DBConstants.CATEGORY_ITEM_DISCOUNT)));
                    if(cursor.getInt(cursor.getColumnIndex(DBConstants.CATEGORY_ITEM_IS_AVAILABLE)) == 0)
                        categoryItem.setIsAvailable(false);
                    else
                        categoryItem.setIsAvailable(true);
                    categoryItem.setImageUrl(cursor.getString(cursor.getColumnIndex(DBConstants.CATEGORY_ITEM_IMAGE_URL)));
                    categoryItem.setDescription(cursor.getString(cursor.getColumnIndex(DBConstants.CATEGORY_ITEM_DESCRIPTION)));

                    categoryItemList.add(categoryItem);
                }
            }
            db.close();
        }catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" getAllCategoryItems "  +e.getMessage());
        } finally {
            db.close();
        }
        return categoryItemList;
    }

    @Override
    public int getCategoryItemCount() {
        int num = 0;
        SQLiteDatabase db = this.getReadableDatabase();
        try{
            Cursor cursor = db.rawQuery(DBQuery.constructSelectAllTableQuery(DBConstants.CATEGORY_ITEM_TABLE), null);
            num = cursor.getCount();
            db.close();
            return num;
        } catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" getCategoryItemCount " +e.getMessage());
        } finally {
            db.close();
        }
        return 0;
    }

    @Override
    public LinkedHashMap<CategoryItem, ArrayList<MenuItem>> getCategoryItemsWithMenuItems(){

        LinkedHashMap<CategoryItem, ArrayList<MenuItem>> categoryItemArrayListMap = new LinkedHashMap<CategoryItem, ArrayList<MenuItem>>();
        ArrayList<CategoryItem> categoryItems = getAllCategoryItems();

        for (CategoryItem categoryItem: categoryItems) {
            categoryItemArrayListMap.put(categoryItem, getMenuItemsFromCategory(categoryItem.getId()));
        }

        return categoryItemArrayListMap;
    }
}
