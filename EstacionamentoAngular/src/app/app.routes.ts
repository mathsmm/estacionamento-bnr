import { Routes } from '@angular/router';
import { MainComponent } from './main/main.component';
import { CrisisListComponent } from './crisis-list/crisis-list.component';
import { HeroesListComponent } from './heroes-list/heroes-list.component';

export const routes: Routes = [
    { path: '', component: MainComponent },
    { path: 'crisis-list', component: CrisisListComponent },
    { path: 'heroes-list', component: HeroesListComponent },
];
