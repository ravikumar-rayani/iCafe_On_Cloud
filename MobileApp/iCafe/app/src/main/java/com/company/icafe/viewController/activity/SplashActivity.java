package com.company.icafe.viewController.activity;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.os.Handler;

import com.company.icafe.R;


/**
 * Created by pmishra on 12/07/16.
 */
public class SplashActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        setContentView(R.layout.splash_layout);

        final Handler handler = new Handler();
        handler.postDelayed(new Runnable() {
            @Override
            public void run() {
                endSplash();
            }
        }, 2000);
    }

    private void endSplash(){
        showApplication();
    }

    private void startApplicationSetup(){

    }

    private void showApplication(){
        Intent intent = new Intent(this, StartSetupActivity.class);
        startActivity(intent);
        finish();
    }
}
