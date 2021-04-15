<template>
  <div v-if="!loading">
    <titulo :content="`Aluno: ${aluno.nome}`" />
    <br />
    <br />
    <div>
        <button v-if="visualize" id="btnEdit" @click="Edit()" class="btn btnEdit">Editar</button>
    </div>

    <table>
      <tbody>
        <tr>
          <td class="column">Matrícula:</td>
          <td>
            <label>{{aluno.id}}</label>
          </td>
        </tr>
        <tr>
          <td class="column">Nome:</td>
          <td>
            <label v-if="visualize">{{aluno.nome}}</label>
            <input v-else v-model="aluno.nome" type="text" />
          </td>
        </tr>
        <tr>
          <td class="column">Endereço:</td>
          <td>
            <label v-if="visualize">{{aluno.endereco}}</label>
            <input v-else v-model="aluno.endereco" type="text" />
          </td>
        </tr>
        <tr>
          <td class="column">Data de Nascimento:</td>
          <td>
            <label v-if="visualize">{{aluno.dataNasc}}</label>
            <input v-else v-model="aluno.dataNasc" type="text" />
          </td>
        </tr>
        <tr>
          <td class="column">Professor:</td>
          <td>
            <label v-if="visualize">{{aluno.professor.nome}}</label>
            <select v-else v-model="aluno.professor.id">
              <option
                v-for="(professor, index) in professores"
                :key="index"
                v-bind:value="professor.id"
              >{{professor.nome}}</option>
            </select>
          </td>
        </tr>
      </tbody>
    </table>

    <div v-if="!visualize">
      <button  id="btnSave" @click="Save(aluno)" class="btn btnSave">Salvar</button>
      &nbsp;
      <button  id="btnCancel" @click="Cancel()" class="btn btnCancel">Cancelar</button>
    </div>


  </div>
</template>

<script>
import Titulo from "../_share/Titulo";

export default {
  components: {
    Titulo,
  },
  data() {
    return {
      professores: [],
      aluno: {},
      id: this.$route.params.id,
      visualize: true,
      loading: true
    };
  },
  created() {
    this.carregarProfessor();
  },
  methods: {
    //Promisse to get all teachers
    carregarProfessor(){
      this.$http.get("http://localhost:5000/api/professor")
      .then((res) => res.json())
      .then((professores) => {
        this.professores = professores;
        this.carregarAluno();
      });
    },
    //Promisse to get one Student
    carregarAluno(){
      this.$http.get(`http://localhost:5000/api/aluno/${this.id}`)
      .then((res) => res.json())
      .then((aluno) => {
        this.aluno = aluno;
        this.loading = false;
      });
    },
    Edit(){
      this.visualize = !this.visualize;
    },
    Save(_aluno){
      let _alunoEditar = {
        id: _aluno.id,
        nome: _aluno.nome,
        endereco: _aluno.endereco,
        dataNasc: _aluno.dataNasc,
        professorid: _aluno.professor.id
      }

      this.$http.put(`http://localhost:5000/api/aluno/${_alunoEditar.id}`, _alunoEditar)
      .then(result => result.json())
      .then(aluno => this.aluno = aluno)
      .then(() => this.visualize = true);

      this.visualize = !this.visualize;

    },
    Cancel(){
      this.visualize = !this.visualize;
    }
  }
};
</script>

<style lang="scss" scoped>
table {
  border-top: 1px solid rgb(226, 225, 225);
  border-bottom: 1px solid rgb(226, 225, 225);
  background-color: rgb(226, 225, 225);
  //border-radius: 4px;
  margin-top: 5px;
  margin-bottom: 5px;
}
table td {
  //background-color: rgb(207, 207, 207);
  //border: 1px solid gray;
  //border-radius: 4px;
  padding: 12px;
}
.column {
  background-color: rgb(207, 207, 207);
  text-align: right;
  font-weight: bold;
  width: 20%;
}
input {
  width: 300px;
  padding: 3px;
}
select {
  width: 300px;
  padding: 3px;
}

</style>