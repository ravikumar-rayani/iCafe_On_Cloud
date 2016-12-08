package com.company.icafe.tasks;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.AsyncTask;
import android.util.Log;

import com.android.volley.DefaultRetryPolicy;
import com.android.volley.Request;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.VolleyLog;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.company.icafe.adapter.ParseJsonData;
import com.company.icafe.callback.InitialDataLoadInterface;
import com.company.icafe.database.MenuDBHandler;
import com.company.icafe.model.CategoryItem;
import com.company.icafe.model.Constants;
import com.company.icafe.model.MenuItem;

import java.io.BufferedReader;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.ArrayList;

import javax.net.ssl.HttpsURLConnection;

/**
 * Created by pmishra on 25/09/16.
 */

public class GetServerResponseTask extends AsyncTask<String, Integer, String> {

    private final String TAG = GetServerResponseTask.class.getSimpleName();
    private Context mContext;
    private ProgressDialog pDialog;
    private InitialDataLoadInterface mCallback;
    boolean offlineMode = true;

    public GetServerResponseTask(Context context, InitialDataLoadInterface callback) {
        this.mContext = context;
        this.mCallback = callback;
    }

    @Override
    protected void onPreExecute() {
        super.onPreExecute();
    }

    @Override
    protected String doInBackground(String... params) {

        // Get Items Category
        String response;
        if(offlineMode)
            response = "[{\"Id\":6,\"Name\":\"Bread\",\"IsAvailable\":true,\"Discount\":null,\"ImageUrl\":null,\"Description\":\"Rotis\"},{\"Id\":7,\"Name\":\"Curry\",\"IsAvailable\":true,\"Discount\":null,\"ImageUrl\":null,\"Description\":\"Curry\"},{\"Id\":8,\"Name\":\"Soup\",\"IsAvailable\":true,\"Discount\":null,\"ImageUrl\":null,\"Description\":\"Soup\"},{\"Id\":9,\"Name\":\"Starter\",\"IsAvailable\":true,\"Discount\":null,\"ImageUrl\":null,\"Description\":\"Starter\"},{\"Id\":15,\"Name\":\"Rice\",\"IsAvailable\":true,\"Discount\":null,\"ImageUrl\":null,\"Description\":\"Rice\"}]";
        else
            response = getStringFromURL(Constants.LOCAL_SERVER_URL + Constants.GET_CATEGORY_URL);
        Log.e(Constants.APP_LOG_TAG, TAG + " Get Items Category" + response);

        ArrayList<CategoryItem> categoryItems = ParseJsonData.newInstance(mContext).parseCategoryItemData(response.toString());
        MenuDBHandler.getInstance(mContext).addCategoryDataItemList(categoryItems);

        // Get All menu items
        String itemResponse;
        if(offlineMode)
            itemResponse = "[{\"Id\":2,\"Name\":\"Naan\",\"ItemCategoryId\":6,\"IsAvailable\":true,\"Discount\":0.00,\"Price\":40.00,\"SpicyLevel\":3,\"Ingrediants\":[\"\"],\"Tags\":[2],\"Description\":null,\"SmallImage\":null,\"FullImage\":null},{\"Id\":3,\"Name\":\"Pulka\",\"ItemCategoryId\":6,\"IsAvailable\":true,\"Discount\":0.00,\"Price\":50.00,\"SpicyLevel\":2,\"Ingrediants\":[\"\"],\"Tags\":[2],\"Description\":null,\"SmallImage\":null,\"FullImage\":null},{\"Id\":4,\"Name\":\"Paneer Masala\",\"ItemCategoryId\":7,\"IsAvailable\":true,\"Discount\":1.00,\"Price\":210.00,\"SpicyLevel\":1,\"Ingrediants\":[\"\"],\"Tags\":[2],\"Description\":null,\"SmallImage\":null,\"FullImage\":null},{\"Id\":5,\"Name\":\"Chicken Masala\",\"ItemCategoryId\":7,\"IsAvailable\":true,\"Discount\":1.00,\"Price\":250.00,\"SpicyLevel\":5,\"Ingrediants\":[\"\"],\"Tags\":[3],\"Description\":null,\"SmallImage\":null,\"FullImage\":null},{\"Id\":6,\"Name\":\"Tundoori\",\"ItemCategoryId\":8,\"IsAvailable\":true,\"Discount\":0.00,\"Price\":40.00,\"SpicyLevel\":3,\"Ingrediants\":[\"\"],\"Tags\":[2],\"Description\":null,\"SmallImage\":\"small image\",\"FullImage\":\"full image\"},{\"Id\":7,\"Name\":\"Pulcha\",\"ItemCategoryId\":8,\"IsAvailable\":true,\"Discount\":0.00,\"Price\":50.00,\"SpicyLevel\":2,\"Ingrediants\":[\"\"],\"Tags\":[2],\"Description\":null,\"SmallImage\":\"small image\",\"FullImage\":\"full image\"},{\"Id\":8,\"Name\":\"Mixed Veg Curry\",\"ItemCategoryId\":9,\"IsAvailable\":true,\"Discount\":1.00,\"Price\":210.00,\"SpicyLevel\":1,\"Ingrediants\":[\"\"],\"Tags\":[2],\"Description\":null,\"SmallImage\":\"small image\",\"FullImage\":\"full image\"},{\"Id\":9,\"Name\":\"Chicken Masala\",\"ItemCategoryId\":9,\"IsAvailable\":true,\"Discount\":1.00,\"Price\":250.00,\"SpicyLevel\":5,\"Ingrediants\":[\"\"],\"Tags\":[3],\"Description\":null,\"SmallImage\":\"small image\",\"FullImage\":\"full image\"}]";
        else
            itemResponse = getStringFromURL(Constants.LOCAL_SERVER_URL + Constants.GET_MENU_ITEM_URL);
        Log.e(Constants.APP_LOG_TAG, TAG + " Get Items details" + itemResponse);

        ArrayList<MenuItem> menuItems = ParseJsonData.newInstance(mContext).parseMenuItemData(itemResponse.toString());
        MenuDBHandler.getInstance(mContext).addMenuDataItemList(menuItems);

//        getStringFromVolley();

        return null;
    }

    @Override
    protected void onProgressUpdate(Integer... values) {
        super.onProgressUpdate(values);
    }

    @Override
    protected void onPostExecute(String boolean1) {
        ArrayList<CategoryItem> categoryItems = MenuDBHandler.getInstance(mContext).getAllCategoryItems();
        if(categoryItems.size() > 0)
            mCallback.dataLoaded();
        Log.e(Constants.APP_LOG_TAG, TAG + categoryItems.size());
    }

    private String getStringFromURL(String url) {
        HttpURLConnection urlConnection = null;
        try {
            URL uri = new URL(url);
            urlConnection = (HttpURLConnection) uri.openConnection();
            int statusCode = urlConnection.getResponseCode();
            if (statusCode != HttpsURLConnection.HTTP_OK) {
                return null;
            }

            InputStream inputStream = urlConnection.getInputStream();
            StringBuffer stringBuffer = new StringBuffer();
            if (inputStream != null) {
                BufferedReader reader = new BufferedReader(new InputStreamReader(inputStream));

                String line = "";

                while ((line = reader.readLine()) != null) {
                    stringBuffer.append(line);
                }
            }
            Log.e(Constants.APP_LOG_TAG, "getStringFromURL " + stringBuffer.toString());
            return stringBuffer.toString();
        } catch (Exception e) {
            urlConnection.disconnect();
            Log.e(Constants.APP_LOG_TAG, "catch exception getStringFromURL ");
        } finally {
            if (urlConnection != null) {
                urlConnection.disconnect();
            }
        }

        return null;
    }

    private void getStringFromVolley() {
        StringRequest strReq = new StringRequest(Request.Method.GET, Constants.LOCAL_SERVER_URL + Constants.GET_CATEGORY_URL, new Response.Listener<String>() {

            @Override
            public void onResponse(String response) {
                Log.d(TAG, response.toString());

                if(MenuDBHandler.getInstance(mContext).getCategoryItemCount() <= 0)
                    MenuDBHandler.getInstance(mContext).
                            addCategoryDataItemList(ParseJsonData.newInstance(
                                    mContext).parseCategoryItemData(response.toString()));

            }
        }, new Response.ErrorListener() {

            @Override
            public void onErrorResponse(VolleyError error) {
                VolleyLog.d(Constants.APP_LOG_TAG, TAG + "Error: " + error.getMessage());

            }
        });

//        ConnectionHandler.getInstance(mContext).addToRequestQueue(strReq);

        Volley.newRequestQueue(mContext).add(strReq).setRetryPolicy(new DefaultRetryPolicy(
                10000,
                DefaultRetryPolicy.DEFAULT_MAX_RETRIES,
                DefaultRetryPolicy.DEFAULT_BACKOFF_MULT));
    }
}
