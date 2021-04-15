<template>
    <div class="barraTop">
        <nav class="marginPrincipal">
            <router-link to="/professores">Professores</router-link>
            <router-link to="/alunos">Alunos</router-link>
            <router-link to="/sobre">Sobre</router-link>
        </nav>
    </div>
</template>

<script>
    export default {
        
    }
</script>

<style lang="scss" scoped>
.barraTop{
    background-color: rgb(230, 230, 230);
}

nav {
    padding: 20px 20px 20px 0px;
}
nav a{
    padding: 20px;
    text-decoration: none;
    background-color: #fff;
    border-radius: 3px;
    color: rgb(36, 35, 35);
    font-weight: bold;
    margin-right: 2px;
}
nav .router-link-active{
    background-color: rgb(160, 160, 160);
    color: white;
}
</style>