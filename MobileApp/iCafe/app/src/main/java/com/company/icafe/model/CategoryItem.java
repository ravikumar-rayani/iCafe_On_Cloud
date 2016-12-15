package com.company.icafe.model;

import com.fasterxml.jackson.annotation.JsonProperty;

/**
 * Created by 20105480 on 28-09-2016.
 */
public class CategoryItem
{
    @JsonProperty("Name")
    private String name;

    @JsonProperty("IsAvailable")
    private boolean isAvailable;

    @JsonProperty("Description")
    private String description;

    @JsonProperty("ImageUrl")
    private String imageUrl;

    @JsonProperty("Discount")
    private int discount;

    @JsonProperty("Id")
    private int id;

    public String getName ()
    {
        return name;
    }

    public void setName (String Name)
    {
        this.name = Name;
    }

    public boolean isAvailable()
    {
        return isAvailable;
    }

    public void setIsAvailable (boolean IsAvailable)
    {
        this.isAvailable = IsAvailable;
    }

    public String getDescription ()
    {
        return description;
    }

    public void setDescription (String Description)
    {
        this.description = Description;
    }

    public String getImageUrl ()
{
    return imageUrl;
}

    public void setImageUrl (String ImageUrl)
    {
        this.imageUrl = ImageUrl;
    }

    public int getDiscount ()
{
    return discount;
}

    public void setDiscount (int Discount)
    {
        this.discount = Discount;
    }

    public int getId ()
    {
        return id;
    }

    public void setId (int Id)
    {
        this.id = Id;
    }

    @Override
    public String toString()
    {
        return "ClassPojo [name = "+ name +", isAvailable = "+ isAvailable +", description = "+ description +", imageUrl = "+ imageUrl +", discount = "+ discount +", Id = "+id+"]";
    }
}
