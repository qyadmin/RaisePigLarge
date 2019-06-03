//
//  GetID.m
//  Unity-iPhone
//
//  Created by Weily on 15/5/4.
//
//

#import <AdSupport/ASIdentifierManager.h>

extern "C"{
    char * GetIphoneADID(){
        NSString * idAD = [[[ASIdentifierManager sharedManager] advertisingIdentifier] UUIDString];
//        char *char_con = [idAD]
        
        
        //        return [@"abc" UTF8String];
        NSLog(@" === %@",idAD);
        const char *a = [idAD UTF8String];
        char * b = (char*)malloc(strlen(a)+1);
        strcpy(b, a);
        return b;
    }
}
