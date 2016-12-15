package com.company.icafe.adapter;

import android.content.Context;
import android.util.Log;

import com.company.icafe.R;
import com.company.icafe.model.CategoryItem;
import com.company.icafe.model.Constants;
import com.company.icafe.model.MenuItem;
import com.company.icafe.model.Order;
import com.fasterxml.jackson.databind.DeserializationFeature;
import com.fasterxml.jackson.databind.ObjectMapper;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;

/**
 * Created by pmishra on 23/07/16.
 */

public class ParseJsonData {

    Context context;

    public static ParseJsonData newInstance(Context context) {
        ParseJsonData parseJsonData = new ParseJsonData();
        parseJsonData.context = context;
        return parseJsonData;
    }

    public ArrayList<CategoryItem> parseCategoryItemData(String jsonResponse) {

        ArrayList<CategoryItem> categoryItemArrayList = new ArrayList<>();

        try {
            ObjectMapper objectMapper = new ObjectMapper();
            objectMapper.configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false);
            categoryItemArrayList = objectMapper.readValue(jsonResponse.getBytes(),
                    objectMapper.getTypeFactory().constructCollectionType(ArrayList.class, CategoryItem.class));
        } catch (FileNotFoundException e){

        } catch (IOException e){
            Log.e(Constants.APP_LOG_TAG,"parseCategoryItemData : "+e.getMessage());
        }

        return categoryItemArrayList;
    }

    public ArrayList<MenuItem> parseMenuItemData(String jsonResponse) {

        ArrayList<MenuItem> menuItemArrayList = new ArrayList<>();

        try {
            ObjectMapper objectMapper = new ObjectMapper();
            objectMapper.configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false);
            menuItemArrayList = objectMapper.readValue(jsonResponse.getBytes(),
                    objectMapper.getTypeFactory().constructCollectionType(ArrayList.class, MenuItem.class));
        } catch (FileNotFoundException e){

        } catch (IOException e){
            Log.e(Constants.APP_LOG_TAG,"parseMenuItemData : "+e.getMessage());
        }

        return menuItemArrayList;
    }

    public ArrayList<Order> parseOrderItemData() {

        ArrayList<Order> orderArrayList = new ArrayList<>();

        try {
            InputStream is = context.getResources().openRawResource(R.raw.randon_order_data);

            int size = is.available();

            byte[] buffer = new byte[size];

            is.read(buffer);

            is.close();

            ObjectMapper objectMapper = new ObjectMapper();
            objectMapper.configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false);
            orderArrayList = objectMapper.readValue(buffer, objectMapper.getTypeFactory().constructCollectionType(ArrayList.class, Order.class));
        } catch (FileNotFoundException e){

        } catch (IOException e){
            Log.e(Constants.APP_LOG_TAG,"parseOrderItemData : "+e.getMessage());
        }

        return orderArrayList;
    }
}
