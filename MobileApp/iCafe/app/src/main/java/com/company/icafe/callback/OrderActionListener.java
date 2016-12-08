package com.company.icafe.callback;

import com.company.icafe.model.Order;
import com.company.icafe.model.SubOrder;
import com.company.icafe.model.SubOrderItem;

import java.util.ArrayList;

/**
 * Created by 20105480 on 26-08-2016.
 */
public interface OrderActionListener {

    public void addOrderList(ArrayList<Order> ordersList);

    public ArrayList<Order> getOrdersListWithContent();

    public ArrayList<Order> getOrderList();

    public ArrayList<SubOrder> getSubOrderArrayList(String orderId);

    public ArrayList<SubOrderItem> getSubOrderItemsArrayList(String subOrderId);

    public int getOrderCount();

    public int getSubOrderCount(String orderId);

    public int getSubOrderItemCount(String subOrderId);
}
