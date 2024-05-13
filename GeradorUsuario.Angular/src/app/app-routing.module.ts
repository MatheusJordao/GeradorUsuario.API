import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CommonModule } from '@angular/common';

import { UsuarioComponent } from './components/usuario/usuario.component';
import { UsuarioListaComponent } from './components/usuario/usuario-lista/usuario-lista.component';
import { UsuarioDetalheComponent } from './components/usuario/usuario-detalhe/usuario-detalhe.component';

const routes: Routes = [
{
  path: 'usuario', component: UsuarioComponent,
  children: [
    { path: '', component: UsuarioListaComponent },
    { path: 'detalhe', component: UsuarioDetalheComponent },
    { path: 'detalhe/:id', component: UsuarioDetalheComponent }
  ]
},
{ path: '', redirectTo: '/usuario', pathMatch: 'full' },
{ path: '**', redirectTo: '/usuario', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes), CommonModule ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
