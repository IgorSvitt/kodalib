<template>
  <p>
    <input type="text" :placeholder="'Id #' + (idPerson + 1)" class="item-input" v-model="person.id" @input="'update:modelValue', $event.target.value"/>
  </p>
  <p>
    <input type="text" :placeholder="'PersonPage fullname'" class="item-input" v-model="person.name" @input="'update:modelValue', $event.target.value"/>
  </p>

</template>

<script>
import {computed} from "vue";

export default {
  name: "ItemForListPerson",
  props: {
    idPerson: {},
    personModel:{}
  },
  setup(props){
    const person = computed(() => props.personModel)

    return{
      person
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