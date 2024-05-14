import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { Usuario } from '../../../_models/Usuario';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-usuario-detalhe',
  templateUrl: './usuario-detalhe.component.html',
  styleUrls: ['./usuario-detalhe.component.css']
})
export class UsuarioDetalheComponent implements OnInit {
  usuarioId: string | null = null;

  public profileForm = new FormGroup({
    id: new FormControl(''),
    nomeUsuario: new FormControl(''),
    email: new FormControl(''),
    senha: new FormControl('')
  });

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id !== null) {
        this.usuarioId = id;
        this.carregarDetalhesUsuario();
      }
    });
  }

  carregarDetalhesUsuario(): void {
    this.http.get<Usuario>(`https://localhost:7094/api/Usuario/${this.usuarioId}`)
      .subscribe(
        (data) => {
          if (data) {
            this.profileForm.patchValue({
              id: data.uuid,
              nomeUsuario: data.nomeUsuario,
              email: data.email,
              senha: data.senha
            });
          } else {
            console.error('Os detalhes do usuário não puderam ser carregados.');
          }
        },
        error => {
          console.error('Erro ao buscar detalhes do usuário:', error);
        }
      );
  }

  salvarUsuario(): void {
    const usuario: Usuario = {
      uuid: this.usuarioId === null ? '' : this.usuarioId,
      nomeUsuario: this.profileForm.value.nomeUsuario || '',
      email: this.profileForm.value.email || '',
      senha: this.profileForm.value.senha || ''
    };

    const { uuid, ...usuarioSemUuid } = usuario;
    const body = new FormData();
    Object.entries(usuarioSemUuid).forEach(([key, value]) => {
      body.append(key, value);
    });

    if (this.usuarioId !== null) {
      // Lógica para atualizar um usuário existente
      this.http.put<any>(`https://localhost:7094/api/Usuario/${this.usuarioId}`, body)
        .subscribe(
          () => {
            console.log('Usuário atualizado com sucesso.');
            this.router.navigate(['/usuario/lista']);
          },
          error => {
            console.error('Erro ao atualizar usuário:', error);
          }
        );
    } else {
      // Lógica para criar um novo usuário
      this.http.post<any>(`https://localhost:7094/api/Usuario`, body)
        .subscribe(
          () => {
            console.log('Novo usuário criado com sucesso.');
            this.router.navigate(['/usuario/lista']);
          },
          error => {
            console.error('Erro ao criar novo usuário:', error);
          }
        );
    }
  }
}
