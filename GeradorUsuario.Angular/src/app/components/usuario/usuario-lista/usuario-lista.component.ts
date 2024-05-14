import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Usuario } from '../../../_models/Usuario';

@Component({
  selector: 'app-usuario-lista',
  templateUrl: './usuario-lista.component.html',
  styleUrls: ['./usuario-lista.component.css']
})
export class UsuarioListaComponent implements OnInit {
  usuarios: Usuario[] = [];
  public loading = false;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.carregarUsuarios();
  }

  carregarUsuarios(): void {
    this.loading = true;
    this.http.get<Usuario[]>('https://localhost:7094/api/Usuario/GetAll')
      .subscribe(
        usuarios => {
          this.usuarios = usuarios;
          this.loading = false;
        },
        error => {
          console.error('Erro ao carregar usuários:', error);
          this.loading = false;
        }
      );
  }

  novoUsuario(): void {
    this.router.navigate(['/usuario/detalhe']);
  }

  novoUsuarioAleatorio(): void {
    if (confirm('Tem certeza que deseja criar um novo usuário aleatório?')) {
      const headers = { 'Content-Type': 'application/json' };

      this.loading = true;
      this.http.post(`https://localhost:7094/api/Usuario/AddUsuarioAleatorio`, {}, { headers })
        .subscribe(
          () => {
            console.log('Usuário criado com sucesso.');
            this.loading = false;
            this.carregarUsuarios();
          },
          error => {
            console.error('Erro ao excluir usuário:', error);
            this.loading = false;
          }
        );
    }
  }

  excluirUsuario(id: string): void {
    if (confirm('Tem certeza que deseja excluir este usuário?')) {
      this.loading = true;
      this.http.delete(`https://localhost:7094/api/Usuario/${id}`)
        .subscribe(
          () => {
            console.log('Usuário excluído com sucesso.');
            this.loading = false;
            this.carregarUsuarios();
          },
          error => {
            console.error('Erro ao excluir usuário:', error);
            this.loading = false;
          }
        );
    }
  }
}
