package com.company.icafe.model;

/**
 * Created by 20105480 on 26-08-2016.
 */
public class SubOrder {

    private String subOrderId;

    private String parentOrderId;

    private SubOrderItem[] subOrderItems;

    private int subOrderPrice;

    private int subOrderStatus;

    public String getSubOrderId() {
        return subOrderId;
    }

    public void setSubOrderId(String subOrderId) {
        this.subOrderId = subOrderId;
    }

    public String getParentOrderId() {
        return parentOrderId;
    }

    public void setParentOrderId(String parentOrderId) {
        this.parentOrderId = parentOrderId;
    }

    public SubOrderItem[] getSubOrderItems() {
        return subOrderItems;
    }

    public void setSubOrderItems(SubOrderItem[] subOrderItems) {
        this.subOrderItems = subOrderItems;
    }

    public int getSubOrderPrice() {
        return subOrderPrice;
    }

    public void setSubOrderPrice(int subOrderPrice) {
        this.subOrderPrice = subOrderPrice;
    }

    public int getSubOrderStatus() {
        return subOrderStatus;
    }

    public void setSubOrderStatus(int subOrderStatus) {
        this.subOrderStatus = subOrderStatus;
    }
}
