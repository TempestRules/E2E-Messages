import { Routes } from '@angular/router';
import { FrontComponent } from './front/front.component';
import { SignInComponent } from './front/sign-in/sign-in.component';
import { SignUpComponent } from './front/sign-up/sign-up.component';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
    { path: '', redirectTo: 'front/sign-in', pathMatch: 'full'},
    { path: 'front', redirectTo: 'front/sign-in', pathMatch: 'full'},
    { path: 'front', component: FrontComponent, 
        children: [
            { path: 'sign-in', component: SignInComponent },
            { path: 'sign-up', component: SignUpComponent}
        ]
    },
    { path: 'home', component: HomeComponent },
    { path: '**', redirectTo: 'front/sign-in' }
];
