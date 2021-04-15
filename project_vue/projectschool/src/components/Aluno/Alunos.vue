<template>
  <div>
    <titulo :content="professor.id != undefined ? 'Professor: ' + professor.nome : 'Alunos Cadastrados'"/>
    <div v-if="professor.id != undefined">
      <p><input type="text" placeholder="Nome do aluno" v-model="nome"></p>
      <p><input type="text" placeholder="Endereço" v-model="endereco"></p>
      <p><button class="btn" v-on:click="addAluno()">Adicionar</button></p>
    </div>
    <br>
    <br>

    <table id="tblAlunos">
      <thead>
        <th>Matrícula</th>
        <th>Nome</th>
        <th>Endereço</th>
        <th></th>
      </thead>
      <tbody v-if="alunos.length">
        <tr v-for="(data, index) in alunos" :key="index">
          <td style="width: 15%;">{{data.id}}</td>
          <router-link tag="td" :to="`/alunoDetalhe/${data.id}`" style="cursor: pointer;">
            {{data.nome}}
          </router-link>
          <td>{{data.endereco}}</td>
          <td>
            <button class="btn-rmv" v-on:click="rmvAluno(data)" style="cursor: pointer;">Remover</button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3"><h4>Nenhum aluno encontrado..</h4></td>
        </tr>
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";

export default {
  components: {
    Titulo
  },
  data() {
    return {
      titulo: "Cadastro de Alunos",
      professorid: this.$route.params.prof_id,
      professor: {},
      nome: "",
      endereco: "",
      alunos: []
    };
  },
  created(){
    if(this.professorid){
      this.getProfessores();
      this.$http
        .get(`http://localhost:5000/api/aluno/byprofessor/${this.professorid}`)
        .then(res => res.json())
        .then(alunos => this.alunos = alunos);
    }else{
      this.$http
        .get("http://localhost:5000/api/aluno")
        .then(res => res.json())
        .then(alunos => this.alunos = alunos);
    }
  },
  props: {},
  methods: {
    addAluno() {
      let _aluno ={
        id: this.id,
        nome: this.nome,
        endereco: this.endereco,
        dataNasc: "",
        professorid: this.professor.id
      }

    this.$http
      .post('http://localhost:5000/api/aluno', _aluno)
      .then(res => res.json())
      .then(dataReturned => {
          this.alunos.push(dataReturned);
          this.nome = '';
          this.endereco = '';
      });

    },
    rmvAluno(aluno){
      this.$http
        .delete(`http://localhost:5000/api/aluno/${aluno.id}`)
        .then(res => {
          let i = this.alunos.indexOf(aluno);
          this.alunos.splice(i, 1);
        });
    },
    getProfessores(){
      this.$http
      .get('http://localhost:5000/api/professor/' + this.professorid)
      .then(res => res.json())
      .then(professor => {
        this.professor = professor
      })
    }
  }
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
table {
  border: 1px solid #eee;
}

p{
  margin: 5px;
}
</style>
