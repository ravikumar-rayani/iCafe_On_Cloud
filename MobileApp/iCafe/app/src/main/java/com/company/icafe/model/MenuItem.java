package com.company.icafe.model;

import android.os.Parcel;
import android.os.Parcelable;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * Created by pmishra on 14/07/16.
 */

public class MenuItem implements Parcelable {
    @JsonProperty("Id")
    private int id;

    @JsonProperty("Name")
    private String name;

    @JsonProperty("ItemCategoryId")
    private int itemCategoryId;

    @JsonProperty("IsAvailable")
    private boolean isAvailable;

    @JsonProperty("Price")
    private int price;

    @JsonProperty("SpicyLevel")
    private int spicyLevel;

    @JsonProperty("Ingrediants")
    private String[] ingredients;

    @JsonProperty("Description")
    private String description;

    @JsonProperty("Tags")
    private String[] tags;

    @JsonProperty("FullImage")
    private String picture;

    private String fullpicture;

    private int quantity = 0;

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getItemCategoryId() {
        return itemCategoryId;
    }

    public void setItemCategoryId(int itemCategoryId) {
        this.itemCategoryId = itemCategoryId;
    }

    public boolean isAvailable() {
        return isAvailable;
    }

    public void setAvailable(boolean available) {
        isAvailable = available;
    }

    public int getPrice() {
        return price;
    }

    public void setPrice(int price) {
        this.price = price;
    }

    public int getSpicyLevel() {
        return spicyLevel;
    }

    public void setSpicyLevel(int spicyLevel) {
        this.spicyLevel = spicyLevel;
    }

    public String[] getIngredients() {
        return ingredients;
    }

    public void setIngredients(String[] ingredients) {
        this.ingredients = ingredients;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String[] getTags() {
        return tags;
    }

    public void setTags(String[] tags) {
        this.tags = tags;
    }

    public String getPicture() {
        return picture;
    }

    public void setPicture(String picture) {
        this.picture = picture;
    }

    public String getFullpicture() {
        return fullpicture;
    }

    public void setFullpicture(String fullpicture) {
        this.fullpicture = fullpicture;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    public int increaseQuantity ()
    {
        quantity = quantity+1;
        return quantity;
    }

    public int decreaseQuantity ()
    {
        if(quantity > 0)
            quantity = quantity-1;
        return quantity;
    }

    @Override
    public String toString()
    {
        return "ClassPojo [tags = "+tags+", picture = "+picture+", name = "+ name +", price = "+price+", id = "+ id +", fullpicture = "+fullpicture+"]";
    }

    @Override
    public int describeContents() {
        return 0;
    }

    @Override
    public void writeToParcel(Parcel dest, int flags) {
        dest.writeInt(this.id);
        dest.writeString(this.name);
        dest.writeInt(this.itemCategoryId);
        dest.writeByte(this.isAvailable ? (byte) 1 : (byte) 0);
        dest.writeInt(this.price);
        dest.writeInt(this.spicyLevel);
        dest.writeStringArray(this.ingredients);
        dest.writeString(this.description);
        dest.writeStringArray(this.tags);
        dest.writeString(this.picture);
        dest.writeString(this.fullpicture);
        dest.writeInt(this.quantity);
    }

    public MenuItem() {
    }

    protected MenuItem(Parcel in) {
        this.id = in.readInt();
        this.name = in.readString();
        this.itemCategoryId = in.readInt();
        this.isAvailable = in.readByte() != 0;
        this.price = in.readInt();
        this.spicyLevel = in.readInt();
        this.ingredients = in.createStringArray();
        this.description = in.readString();
        this.tags = in.createStringArray();
        this.picture = in.readString();
        this.fullpicture = in.readString();
        this.quantity = in.readInt();
    }

    public static final Parcelable.Creator<MenuItem> CREATOR = new Parcelable.Creator<MenuItem>() {
        @Override
        public MenuItem createFromParcel(Parcel source) {
            return new MenuItem(source);
        }

        @Override
        public MenuItem[] newArray(int size) {
            return new MenuItem[size];
        }
    };
}
