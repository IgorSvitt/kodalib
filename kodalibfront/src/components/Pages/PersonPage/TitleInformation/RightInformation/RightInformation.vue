<template>
<div>
  <div class="title">
    Films
  </div>
  <div v-for="film in information" :key="film.id" class="list-films">
    <a :href="'/film/'+film.id">{{film.title}}</a>
  </div>
</div>
</template>

<script>
export default {
  name: "RightINformation",
  props:{
    information:{}
  }
}
</script>

<style scoped>
.title{
  font-size: 30px;
  margin-bottom: 20px;
  margin-left: 20px;
}

.list-films{
  margin-left: 20px;
  font-size: 20px;
  margin-bottom: 10px;
}

a{
  color: #4e3883;
}

a:hover{
  color: #fed534;
}
</style>