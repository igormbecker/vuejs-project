<template>
    <div>
        <div style="display: flex; width: 100%;">
            <div class="voltar">
                <button class="btn btnBack" @click="voltar()">Voltar</button>
            </div>     
            <div class="divContent">
                <h1>{{content}}</h1>
            </div>       
            
        </div>

    </div>
</template>

<script>
    export default {
        props:{
            content: String
        },
        methods: {
            voltar(){
                this.$router.back();
            }
        },
    }
</script>

<style lang="scss">
.voltar{
    width: 50%;
    position: absolute;
    margin-top: 15px;
}
.btn{
    //border-radius: 2px;
    //margin: 5px;
    border-radius: 4px;
    border: 1px solid rgb(87, 87, 87);
    padding: 8px;
    color: rgb(0, 0, 0);
    font-weight: bold;
}
.btnBack{
    float: right;
    background-color: rgb(177, 177, 177);
    color: rgb(0, 0, 0);
}
.btnEdit{
  background-color: rgb(0, 162, 255);
}
.btnSave{
  background-color: rgb(50, 138, 15);
}
.btnCancel{
  background-color: rgb(216, 42, 42);
}
.divContent{
    margin-top: 50px; 
    width: 100%;
    /*border: 1px solid black;*/
}
</style>