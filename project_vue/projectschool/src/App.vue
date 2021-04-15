<template>
  <div id="app">
    <Nav></Nav>
    <div class="marginPrincipal">
      <router-view :key="$route.fullPath"></router-view>
    </div>
  </div>
</template>

<script>
import Alunos from './components/Aluno/Alunos.vue';
//import AlunoCadastro from './components/Aluno/AlunoCadastro.vue';
import Professor from './components/Professor/Professores.vue';
import Nav from './components/_nav/Nav.vue';

export default {
  name: 'app',
  components: {
    Alunos,
    //AlunoCadastro,
    Professor,
    Nav
  }
}
</script>

<style>
body{
  background-color: #eee;
  /*Serve para deixar todo conteúdo do body centralizado/responsivo */
  display: grid;
  justify-items: center;
  /*Fim*/
}
body, html{
  margin: 0px;
  
}

table {
  margin: 0px;
  padding: 0px;
  max-width: 700px;
  min-width: 200px;
  width: 550px;
}
table thead th{
  background-color: rgb(212, 212, 212) !important;
  padding: 5px 0px;
  font-size: 18px;
}
table tfoot td{
  text-align: center;
}

.marginPrincipal{
width: 50%;
margin-left: auto;
margin-right: auto;
}

#app {
width: 100%;
}

.btn-rmv{
  background-color: rgba(131, 0, 0, 0.726);
  border: 1px solid black;
  color: white;
  cursor: pointer;
  font-weight: bold;
  border-radius: 4px;
  border-bottom: 2px solid black;
  margin: 2px;
  padding: 3px;
}
.btn-rmv:hover{
  text-shadow: 1px 1px 1px black;
}
</style>
