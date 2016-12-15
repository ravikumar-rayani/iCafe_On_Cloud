package com.company.icafe.database;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

import com.company.icafe.callback.OrderActionListener;
import com.company.icafe.model.Constants;
import com.company.icafe.model.DateAndTimeDeserialize;
import com.company.icafe.model.Order;
import com.company.icafe.model.SubOrder;
import com.company.icafe.model.SubOrderItem;

import java.util.ArrayList;

/**
 * Created by 20105480 on 26-08-2016.
 */
public class OrderDBHandler extends DBHandler implements OrderActionListener{

    private final String LOG_TAG = OrderDBHandler.class.getSimpleName();

    private static OrderDBHandler orderDBHandler;

    public static OrderDBHandler getInstance(Context context){
        if(orderDBHandler == null)
            orderDBHandler = new OrderDBHandler(context);
        return orderDBHandler;
    }

    private OrderDBHandler(Context context) {
        super(context);
    }

    @Override
    public void addOrderList(ArrayList<Order> ordersList) {
        SQLiteDatabase sqLiteDatabase = this.getWritableDatabase();

        try{
            for (Order order: ordersList) {
                ContentValues orderTableValues = new ContentValues();

                orderTableValues.put(DBConstants.ORDER_ID, order.getOrderId());
                orderTableValues.put(DBConstants.ORDER_PRICE, order.getOrderTotalPrice());
                orderTableValues.put(DBConstants.ORDER_PAYMENT_STATUS, order.isPaymentStatus());
                orderTableValues.put(DBConstants.ORDER_CREATED_DATE, order.getCreatedOn().toString());
                orderTableValues.put(DBConstants.ORDER_MODIFIED_DATE, order.getModifiedOn().toString());

                sqLiteDatabase.insert(DBConstants.ORDER_TABLE_NAME, null, orderTableValues);

                fillOrderDetailsTable(order.getOrderId(), order.getSubOrders(), sqLiteDatabase);
            }

        } catch (Exception e){
            Log.e(Constants.APP_LOG_TAG, LOG_TAG+" addOrderList "  + e.getMessage());
        }
        sqLiteDatabase.close();
    }

    private void fillOrderDetailsTable(String orderId, SubOrder[] subOrders, SQLiteDatabase sqLiteDatabase){
        try {
            for (SubOrder subOrder : subOrders) {
                ContentValues orderDetailsTableValues = new ContentValues();

                orderDetailsTableValues.put(DBConstants.ORDER_ID, orderId);
                orderDetailsTableValues.put(DBConstants.SUB_ORDER_ID, subOrder.getSubOrderId());

                sqLiteDatabase.insert(DBConstants.ORDER_DETAILS_TABLE_NAME, null, orderDetailsTableValues);

                fillSubOrderTable(subOrder, sqLiteDatabase);
            }
        } catch (Exception e){
            Log.e(Constants.APP_LOG_TAG, LOG_TAG+" fillOrderDetailsTable "  + e.getMessage());
        }
    }

    private void fillSubOrderTable(SubOrder subOrder, SQLiteDatabase sqLiteDatabase){
        try {
            ContentValues subOrderTableValues = new ContentValues();

            subOrderTableValues.put(DBConstants.SUB_ORDER_ID, subOrder.getSubOrderId());
            subOrderTableValues.put(DBConstants.SUB_ORDER_PRICE, subOrder.getSubOrderPrice());
            subOrderTableValues.put(DBConstants.SUB_ORDER_STATUS, subOrder.getSubOrderStatus());

            sqLiteDatabase.insert(DBConstants.SUB_ORDER_TABLE_NAME, null, subOrderTableValues);

            fillSubOrderItemsTable(subOrder, subOrder.getSubOrderItems(), sqLiteDatabase);

        } catch (Exception e){
            Log.e(Constants.APP_LOG_TAG, LOG_TAG+" fillSubOrderTable "  + e.getMessage());
        }
    }

    private void fillSubOrderItemsTable(SubOrder subOrder, SubOrderItem[] subOrderItems, SQLiteDatabase sqLiteDatabase){
        try {
            for (SubOrderItem subOrderItem: subOrderItems) {
                ContentValues subOrderItemTableValues = new ContentValues();

                subOrderItemTableValues.put(DBConstants.SUB_ORDER_ID, subOrder.getSubOrderId());
                subOrderItemTableValues.put(DBConstants.SUB_ORDER_ITEM_ID, subOrderItem.getItemId());
                subOrderItemTableValues.put(DBConstants.SUB_ORDER_ITEM_NAME, subOrderItem.getItemName());
                subOrderItemTableValues.put(DBConstants.SUB_ORDER_ITEM_QUANTITY, subOrderItem.getItemQuantity());

                sqLiteDatabase.insert(DBConstants.SUB_ORDER_ITEM_TABLE_NAME, null, subOrderItemTableValues);
            }
        } catch (Exception e){
            Log.e(Constants.APP_LOG_TAG, LOG_TAG+" fillSubOrderItemsTable "  + e.getMessage());
        }
    }

    @Override
    public ArrayList<Order> getOrdersListWithContent() {
        ArrayList<Order> orderArrayList = getOrderList();

        for(int i = 0 ; i  < orderArrayList.size() ; i++) {
            Order order = orderArrayList.get(i);
            orderArrayList.get(i).setSubOrders(convertSubOrderListToSubOrderArray(getSubOrderArrayList(order.getOrderId())));

            for(int j = 0 ; j  < orderArrayList.get(i).getSubOrders().length ; j++) {
                SubOrder subOrder = orderArrayList.get(i).getSubOrders()[j];
                orderArrayList.get(i).getSubOrders()[j].setSubOrderItems(convertSubOrderItemListToSubOrderItemArray(getSubOrderItemsArrayList(subOrder.getSubOrderId())));
            }
        }
        return orderArrayList;
    }

    @Override
    public ArrayList<Order> getOrderList() {
        SQLiteDatabase db = this.getReadableDatabase();
        ArrayList<Order> orderList = null;
        try{
            orderList = new ArrayList<Order>();
            Cursor cursor = db.rawQuery(DBQuery.constructSelectAllTableQuery(DBConstants.ORDER_TABLE_NAME), null);
            if(!cursor.isLast())
            {
                while (cursor.moveToNext())
                {
                    Order order = new Order();
                    order.setOrderId(cursor.getString(cursor.getColumnIndex(DBConstants.ORDER_ID)));
                    order.setOrderTotalPrice(cursor.getInt(cursor.getColumnIndex(DBConstants.ORDER_PRICE)));
                    if(cursor.getInt(cursor.getColumnIndex(DBConstants.ORDER_PAYMENT_STATUS)) == 0)
                        order.setPaymentStatus(false);
                    else
                        order.setPaymentStatus(true);
                    order.setCreatedOn(DateAndTimeDeserialize.convertStringToDate(cursor.getString(cursor.getColumnIndex(DBConstants.ORDER_CREATED_DATE))));
                    order.setModifiedOn(DateAndTimeDeserialize.convertStringToDate(cursor.getString(cursor.getColumnIndex(DBConstants.ORDER_MODIFIED_DATE))));

                    orderList.add(order);
                }
            }
            db.close();
        }catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" getOrderList "  +e.getMessage());
        } finally {
            db.close();
        }
        return orderList;
    }

    @Override
    public ArrayList<SubOrder> getSubOrderArrayList(String orderId) {
        SubOrder[] subOrderArray = null;
        int totalCount = getSubOrderCount(orderId);
        int counter = 0;
        SQLiteDatabase db = this.getReadableDatabase();
        ArrayList<SubOrder> subOrderArrayList = new ArrayList<SubOrder>();
        try{
            subOrderArray = new SubOrder[totalCount];

            Cursor cursor = db.rawQuery(
                    DBQuery.constructSelectAllTableQuery(
                            DBConstants.ORDER_DETAILS_TABLE_NAME) +
                            DBConstants.WHERE +
                            DBConstants.ORDER_ID +
                            DBConstants.WHERE_EXPERSSION,
                    new String[]{
                            orderId
                    });
            if(!cursor.isLast())
            {
                while (cursor.moveToNext())
                {
                    Cursor subOrderCursor = db.rawQuery(
                            DBQuery.constructSelectAllTableQuery(
                                    DBConstants.SUB_ORDER_TABLE_NAME) +
                                    DBConstants.WHERE +
                                    DBConstants.SUB_ORDER_ID +
                                    DBConstants.WHERE_EXPERSSION,
                            new String[]{cursor.getString(
                                    cursor.getColumnIndex(DBConstants.SUB_ORDER_ID))
                            });

                    if(!subOrderCursor.isLast()) {
                        while (subOrderCursor.moveToNext()) {

                            SubOrder subOrder = new SubOrder();
                            subOrder.setSubOrderId(subOrderCursor.getString(subOrderCursor.getColumnIndex(DBConstants.SUB_ORDER_ID)));
                            subOrder.setSubOrderPrice(subOrderCursor.getInt(subOrderCursor.getColumnIndex(DBConstants.SUB_ORDER_PRICE)));
                            subOrder.setSubOrderStatus(subOrderCursor.getInt(subOrderCursor.getColumnIndex(DBConstants.SUB_ORDER_STATUS)));

//                            subOrderArray[counter] = subOrder;
//                            counter++;
                            subOrderArrayList.add(subOrder);
                        }
                    }
                }
            }
            db.close();
        }catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" sgetSubOrderArray "  +e.getMessage());
        } finally {
            db.close();
        }
        return subOrderArrayList;
    }

    @Override
    public ArrayList<SubOrderItem> getSubOrderItemsArrayList(String subOrderId) {
        SubOrderItem[] subOrderItemsArray = null;
        int totalCount = getSubOrderItemCount(subOrderId);
        int counter = 0;
        SQLiteDatabase db = this.getReadableDatabase();
        ArrayList<SubOrderItem> subOrderItemArrayList = new ArrayList<SubOrderItem>();
        try{
            subOrderItemsArray = new SubOrderItem[totalCount];

            Cursor cursor = db.query(
                    DBConstants.SUB_ORDER_ITEM_TABLE_NAME,
                    null,
                    DBConstants.SUB_ORDER_ID + " = ?",
                    new String[] { subOrderId },
                    null,
                    null,
                    null);

            if(!cursor.isLast())
            {
                while (cursor.moveToNext())
                {
                    SubOrderItem subOrderItem = new SubOrderItem();
                    subOrderItem.setItemId(cursor.getString(cursor.getColumnIndex(DBConstants.SUB_ORDER_ITEM_ID)));
                    subOrderItem.setItemName(cursor.getString(cursor.getColumnIndex(DBConstants.SUB_ORDER_ITEM_NAME)));
                    subOrderItem.setItemQuantity(cursor.getInt(cursor.getColumnIndex(DBConstants.SUB_ORDER_ITEM_QUANTITY)));

//                    subOrderItemsArray[counter] = subOrderItem;
//                    counter++;
                    subOrderItemArrayList.add(subOrderItem);
                }
            }
            db.close();
        }catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" getSubOrderItemsArrayList "  +e.getMessage());
        } finally {
            db.close();
        }
        return subOrderItemArrayList;
    }

    @Override
    public int getOrderCount() {
        int num = 0;
        SQLiteDatabase db = this.getReadableDatabase();
        try{
            Cursor cursor = db.rawQuery(DBQuery.constructSelectAllTableQuery(DBConstants.ORDER_TABLE_NAME), null);
            num = cursor.getCount();
            db.close();
            return num;
        } catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" getOrderCount " +e.getMessage());
        } finally {
            db.close();
        }
        return 0;
    }

    @Override
    public int getSubOrderCount(String orderId) {
        int num = 0;
        SQLiteDatabase db = this.getReadableDatabase();
        try {
            Cursor cursor = db.rawQuery(
                    DBQuery.constructSelectAllTableQuery(
                            DBConstants.ORDER_DETAILS_TABLE_NAME) +
                            DBConstants.WHERE +
                            DBConstants.ORDER_ID +
                            DBConstants.WHERE_EXPERSSION,
                    new String[]{
                            orderId
                    });
            num = cursor.getCount();
            db.close();
            return num;
        } catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" getSubOrderCount " +e.getMessage());
        } finally {
            db.close();
        }
        return 0;
    }

    @Override
    public int getSubOrderItemCount(String subOrderId) {
        int num = 0;
        SQLiteDatabase db = this.getReadableDatabase();
        try{
            Cursor cursor = db.query(
                    DBConstants.SUB_ORDER_ITEM_TABLE_NAME,
                    null,
                    DBConstants.SUB_ORDER_ID + " = ?",
                    new String[] { subOrderId },
                    null,
                    null,
                    null);
            num = cursor.getCount();
            db.close();
            return num;
        } catch (Exception e){
            Log.e(Constants.APP_LOG_TAG,LOG_TAG+" getSubOrderItemCount " +e.getMessage());
        } finally {
            db.close();
        }
        return 0;
    }

    private SubOrder[] convertSubOrderListToSubOrderArray(ArrayList<SubOrder> subOrderArrayList){
        SubOrder[] subOrders = new SubOrder[subOrderArrayList.size()];
        for (int i = 0 ; i < subOrderArrayList.size() ; i++)
            subOrders[i] = subOrderArrayList.get(i);
        return subOrders;
    }

    private SubOrderItem[] convertSubOrderItemListToSubOrderItemArray(ArrayList<SubOrderItem> subOrderItemArrayList){
        SubOrderItem[] subOrderItems = new SubOrderItem[subOrderItemArrayList.size()];
        for (int i = 0 ; i < subOrderItemArrayList.size() ; i++)
            subOrderItems[i] = subOrderItemArrayList.get(i);
        return subOrderItems;
    }
}
