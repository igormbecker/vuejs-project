import Vue from 'vue';
import Router from 'vue-router';
import Alunos from './components/Aluno/Alunos';
import AlunoDetalhe from './components/Aluno/AlunoDetalhe';
import Professor from './components/Professor/Professores';
import Sobre from './components/Sobre/Sobre';

Vue.use(Router);

export default new Router({
    routes: [
        {
            path: '/professores',
            nome: 'Professores',
            component: Professor
        },
        {
            path: '/alunos/:prof_id',
            nome: 'Alunos',
            component: Alunos
        },
        {
            path: '/alunoDetalhe/:id',
            nome: 'AlunoDetalhe',
            component: AlunoDetalhe
        },
        {
            path: '/alunos',
            nome: 'Alunos',
            component: Alunos
        },        
        {
            path: '/sobre',
            nome: 'Sobre',
            component: Sobre
        }
    ]
})