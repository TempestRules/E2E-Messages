import { Routes } from '@angular/router';
import { FrontComponent } from './front/front.component';
import { SignInComponent } from './front/sign-in/sign-in.component';
import { SignUpComponent } from './front/sign-up/sign-up.component';

export const routes: Routes = [
    { path: '', redirectTo: 'front/sign-in', pathMatch: 'full'},
    { path: 'front', redirectTo: 'front/sign-in', pathMatch: 'full'},
    { path: 'front', component: FrontComponent, 
        children: [
            { path: 'sign-in', component: SignInComponent },
            { path: 'sign-up', component: SignUpComponent}
        ]
    },
    { path: '**', redirectTo: 'front/sign-in' }
];
