<template>
<div v-show="information.summary !== ''" class="person-summary">
  {{information.summary}}
</div>

</template>

<script>
export default {
  name: "CenterInformation",
  props:{
    information:{
      type: Object
    }
  },
  setup(){

    return{

    }
  }
}
</script>

<style scoped>
.person-summary{
  color: #1B132E;
  font-size: 20px;
}
</style>