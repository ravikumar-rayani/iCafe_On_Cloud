package com.company.icafe.database;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.company.icafe.callback.CartItemActionListener;
import com.company.icafe.model.CartItem;
import com.company.icafe.model.Constants;
import com.company.icafe.model.MenuItem;

import java.util.ArrayList;

/**
 * Created by pmishra on 30/09/16.
 */

public class CartDBHandler extends DBHandler implements CartItemActionListener {

    private final String LOG_TAG = CartDBHandler.class.getSimpleName();

    private static CartDBHandler cartDBHandler;

    public static CartDBHandler getInstance(Context context){
        if(cartDBHandler == null)
            cartDBHandler = new CartDBHandler(context);
        return cartDBHandler;
    }

    private CartDBHandler(Context context) {
        super(context);
    }


    @Override
    public boolean insertOrUpdateMenuItemToCart(MenuItem menuItem) {
        SQLiteDatabase sqLiteDatabase = this.getWritableDatabase();
        try{
            if(menuItem.getQuantity() > 0) {
                ContentValues values = new ContentValues();
                values.put(DBConstants.MENU_ITEM_ID, menuItem.getId());
                values.put(DBConstants.MENU_ITEM_NAME, menuItem.getName());
                values.put(DBConstants.MENU_ITEM_PRICE, menuItem.getPrice());
                values.put(DBConstants.MENU_ITEM_QUANTITY, menuItem.getQuantity());
                values.put(DBConstants.MENU_ITEM_QUANTITY_PRICE, (menuItem.getPrice() * menuItem.getQuantity()));

                sqLiteDatabase.insertWithOnConflict(DBConstants.CART_TABLE_NAME, null, values, SQLiteDatabase.CONFLICT_REPLACE);
            } else {
                sqLiteDatabase.delete(DBConstants.CART_TABLE_NAME,
                        DBConstants.MENU_ITEM_ID + " = ? ",
                        new String[] { Integer.toString(menuItem.getId())});
            }
            sqLiteDatabase.close();
            return true;
        } catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" addMenuItemToCart "  + e.getMessage());
        } finally {
            sqLiteDatabase.close();
        }
        return false;
    }

    @Override
    public ArrayList<CartItem> getCartItemList() {
        SQLiteDatabase db = this.getReadableDatabase();
        ArrayList<CartItem> cartItemList = null;
        try{
            cartItemList = new ArrayList<CartItem>();
            Cursor cursor = db.rawQuery(DBQuery.constructSelectAllTableQuery(DBConstants.CART_TABLE_NAME), null);
            if(!cursor.isLast())
            {
                while (cursor.moveToNext())
                {
                    CartItem cartItem = new CartItem();
                    cartItem.setMenuItemId(cursor.getString(cursor.getColumnIndex(DBConstants.MENU_ITEM_ID)));
                    cartItem.setMenuItemName(cursor.getString(cursor.getColumnIndex(DBConstants.MENU_ITEM_NAME)));
                    cartItem.setMenuItemUnitPrice(cursor.getInt(cursor.getColumnIndex(DBConstants.MENU_ITEM_PRICE)));
                    cartItem.setMenuItemQuantity(cursor.getInt(cursor.getColumnIndex(DBConstants.MENU_ITEM_QUANTITY)));
                    cartItem.setMenuItemQuantityPrice(cursor.getInt(cursor.getColumnIndex(DBConstants.MENU_ITEM_QUANTITY_PRICE)));

                    cartItemList.add(cartItem);
                }
            }
            db.close();
        }catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" getCartItemList "  +e.getMessage());
        } finally {
            db.close();
        }
        return cartItemList;
    }

    @Override
    public boolean updateMenuItemQuantityInCart(CartItem cartItem) {
        SQLiteDatabase sqLiteDatabase = this.getWritableDatabase();
        try{
            if(cartItem.getMenuItemQuantity() > 0) {
                ContentValues values = new ContentValues();
                values.put(DBConstants.MENU_ITEM_ID, cartItem.getMenuItemId());
                values.put(DBConstants.MENU_ITEM_NAME, cartItem.getMenuItemName());
                values.put(DBConstants.MENU_ITEM_PRICE, cartItem.getMenuItemUnitPrice());
                values.put(DBConstants.MENU_ITEM_QUANTITY, cartItem.getMenuItemQuantity());
                values.put(DBConstants.MENU_ITEM_QUANTITY_PRICE, (cartItem.getMenuItemUnitPrice() * cartItem.getMenuItemQuantity()));

                sqLiteDatabase.update(DBConstants.CART_TABLE_NAME,
                        values,
                        DBConstants.MENU_ITEM_ID + " = ? ",
                        new String[] { cartItem.getMenuItemId()});
            } else {
                sqLiteDatabase.delete(DBConstants.CART_TABLE_NAME,
                        DBConstants.MENU_ITEM_ID + " = ? ",
                        new String[] { cartItem.getMenuItemId()});
            }
            sqLiteDatabase.close();
            return true;
        } catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" updateMenuItemQuantityInCart "  + e.getMessage());
        } finally {
            sqLiteDatabase.close();
        }
        return false;
    }

    @Override
    public CartItem getMenuItemFromCart(String cartItemId) {
        /*SQLiteDatabase db = this.getReadableDatabase();
        CartItem cartItem = null;
        try{
            cartItemList = new ArrayList<CartItem>();
            Cursor cursor = db.rawQuery(constructSelectAllTableQuery(DBConstants.CART_TABLE_NAME), new String[] { cartItemId});
            if(!cursor.isLast())
            {
                while (cursor.moveToNext())
                {
                    CartItem cartItem = new CartItem();
                    cartItem.setMenuItemId(cursor.getString(cursor.getColumnIndex(DBConstants.MENU_ITEM_ID)));
                    cartItem.setMenuItemName(cursor.getString(cursor.getColumnIndex(DBConstants.MENU_ITEM_NAME)));
                    cartItem.setMenuItemUnitPrice(cursor.getInt(cursor.getColumnIndex(DBConstants.MENU_ITEM_PRICE)));
                    cartItem.setMenuItemQuantity(cursor.getInt(cursor.getColumnIndex(DBConstants.MENU_ITEM_QUANTITY)));
                    cartItem.setMenuItemQuantityPrice(cursor.getInt(cursor.getColumnIndex(DBConstants.MENU_ITEM_QUANTITY_PRICE)));

                    cartItemList.add(cartItem);
                }
            }
            db.close();
        }catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" getCartItemList "  +e.getMessage());
        } finally {
            db.close();
        }*/
        return null;
    }

    @Override
    public boolean removeMenuItemFromCart(CartItem cartItem) {
        SQLiteDatabase sqLiteDatabase = this.getWritableDatabase();
        try{
            sqLiteDatabase.delete(DBConstants.CART_TABLE_NAME,
                    DBConstants.MENU_ITEM_ID + " = ? ",
                    new String[] { cartItem.getMenuItemId()});
            sqLiteDatabase.close();
            return true;
        } catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" removeMenuItemFromCart "  + e.getMessage());
        } finally {
            sqLiteDatabase.close();
        }
        return false;
    }

    @Override
    public int getCartTotalPrice() {
        ArrayList<CartItem> cartItems = getCartItemList();
        int totalPrice = 0;
        for (CartItem cartItem: cartItems) {
            totalPrice += cartItem.getMenuItemQuantityPrice();
        }
        return totalPrice;
    }

    @Override
    public int getCartItemsCount() {
        ArrayList<CartItem> cartItems = getCartItemList();
        return cartItems.size();
    }
}
