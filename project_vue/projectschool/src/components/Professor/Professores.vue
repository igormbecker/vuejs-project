<template>
  <div>
    <titulo content="Cadastro de Professores"/>
    <table id="tblProfessores">
      <thead>
        <th>Código</th>
        <th>Nome</th>
        <th>Qtd Alunos</th>
        <th></th>
      </thead>
      <tbody v-if="professores.length">
        <tr v-for="(data, index) in professores" :key="index">
          <td style="width: 15%;">{{data.id}}</td>
          <router-link v-bind:to="`/alunos/${data.id}`" tag="td" style="cursor: pointer;">
            {{data.nome}}
          </router-link>
          <td style="width: 15%;">{{data.qtdAlunos}}</td>
        </tr>
      </tbody>
      <tfoot v-else>
        <tr>
          <td colspan="3"><h4>Nenhum professor encontrado..</h4></td>
        </tr>
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from '../_share/Titulo';

export default {
    components: {
      Titulo
    },
    data(){
        return{
            professores: [],
            alunos: []
        }
    },
    created(){
      this.$http
      .get('http://localhost:5000/api/aluno')
      .then(res => res.json())
      .then(alunos => {
        this.alunos = alunos,
        this.getProfessores();
      })
  },
  props: {},
  methods: {
    getAmount(){
      this.professores.forEach((professor, index) => {
        professor = {
          id: professor.id,
          nome: professor.nome,
          qtdAlunos: this.alunos.filter(aluno => 
          aluno.professor.id == professor.id
          ).length
        }
        this.professores[index] = professor;
      })
    },
    getProfessores(){
      this.$http
      .get('http://localhost:5000/api/professor')
      .then(res => res.json())
      .then(professores => {
        this.professores = professores
        this.getAmount();
      })
    }
  },
};
</script>

<style lang="scss" scoped>
p{
  margin: 5px;
}

</style>