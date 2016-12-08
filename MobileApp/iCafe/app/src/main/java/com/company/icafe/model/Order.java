package com.company.icafe.model;

import com.fasterxml.jackson.databind.annotation.JsonDeserialize;

import java.util.Date;

/**
 * Created by 20105480 on 26-08-2016.
 */
public class Order {

    private String orderId;

    private int orderTotalPrice;

    private boolean paymentStatus;

    private String customerId;

    @JsonDeserialize(using=DateAndTimeDeserialize.class)
    private Date createdOn;

    @JsonDeserialize(using=DateAndTimeDeserialize.class)
    private Date modifiedOn;

    private SubOrder[] subOrders;

    public String getOrderId() {
        return orderId;
    }

    public void setOrderId(String orderId) {
        this.orderId = orderId;
    }

    public int getOrderTotalPrice() {
        return orderTotalPrice;
    }

    public void setOrderTotalPrice(int orderTotalPrice) {
        this.orderTotalPrice = orderTotalPrice;
    }

    public boolean isPaymentStatus() {
        return paymentStatus;
    }

    public void setPaymentStatus(boolean paymentStatus) {
        this.paymentStatus = paymentStatus;
    }

    public String getCustomerId() {
        return customerId;
    }

    public void setCustomerId(String customerId) {
        this.customerId = customerId;
    }

    public Date getCreatedOn() {
        return createdOn;
    }

    public void setCreatedOn(Date createdOn) {
        this.createdOn = createdOn;
    }

    public Date getModifiedOn() {
        return modifiedOn;
    }

    public void setModifiedOn(Date modifiedOn) {
        this.modifiedOn = modifiedOn;
    }

    public SubOrder[] getSubOrders() {
        return subOrders;
    }

    public void setSubOrders(SubOrder[] subOrders) {
        this.subOrders = subOrders;
    }
}
