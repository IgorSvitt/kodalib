<template>
  <div class="item-box">
    <span class="item-box-text">{{itemTitle}}</span>
    <p>
      <input type="text" :placeholder="itemTitle" class="item-input" v-model="film" @input="$emit('update:modelValue', $event.target.value)"/>
    </p>
  </div>
</template>

<script>

import {computed} from "vue";

export default {
  name: "ItemUpdate",

  props:{
    itemTitle:{},
    filmModel:{
      type: String
    },
  },
  setup(props){
    const film = computed(() => props.filmModel)

    return{
      film
    }
  }
}
</script>

<style scoped>
.item-box {
  display: block;
  width: 100%;
  padding-left: 50px;
  margin-bottom: 20px;
}

.item-box-text{
  padding-left: 10px;
  color: #503883;
  font-size: 20px;
}

.item-input{
  border-radius: 30px;
  border: 2px solid #503883;
  margin-top: 10px;
  padding: 10px;
  width: 50%
}
</style>