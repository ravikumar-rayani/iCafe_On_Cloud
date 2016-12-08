package com.company.icafe.model;

import com.fasterxml.jackson.core.JsonParser;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.DeserializationContext;
import com.fasterxml.jackson.databind.JsonDeserializer;

import java.io.IOException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by pmishra on 21/08/16.
 */

public class DateAndTimeDeserialize extends JsonDeserializer<Date> {

    private static final SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");

    @Override
    public Date deserialize(JsonParser paramJsonParser,
                            DeserializationContext paramDeserializationContext)
            throws IOException, JsonProcessingException {
        return convertStringToDate(paramJsonParser.getText());
    }

    public static Date convertStringToDate(String dateString){
        if(dateString != null && !dateString.isEmpty()) {
            try {
                return dateFormat.parse(dateString.trim());
            } catch (ParseException e) {
//                Log.e(Constants.APP_LOG_TAG, "DateAndTimeDeserialize: convertStringToDate: " + e.getMessage());
            }
        }
        return new Date();
    }
}
