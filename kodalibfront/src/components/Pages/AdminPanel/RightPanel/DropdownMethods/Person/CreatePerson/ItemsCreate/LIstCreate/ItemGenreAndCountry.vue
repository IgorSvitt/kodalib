<template>
  <p>
    <input type="text" class="item-input" v-model="item.name" @input="'update:modelValue', $event.target.value"/>
  </p>
</template>

<script>
import {ref} from "vue";

export default {
  name: "ItemGenreAndCountry",
  props: {
    itemModel:{
      name:""
    }
  },
  setup(props){
    const item = ref(props.itemModel)

    return{
      item
    }
  }

}
</script>

<style scoped>
.item-input {
  border-radius: 30px;
  border: 2px solid #503883;
  margin-top: 10px;
  padding: 10px;
  width: 50%
}


</style>


ItemGenreAndCountry
