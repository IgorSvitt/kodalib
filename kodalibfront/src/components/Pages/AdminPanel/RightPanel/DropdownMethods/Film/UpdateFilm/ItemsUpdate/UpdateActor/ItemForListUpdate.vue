<template>
  <p>
    <input type="text" :placeholder="'Id #' + (idActor + 1)" class="item-input" v-model="actor.id" @input="'update:modelValue', $event.target.value"/>
  </p>
  <p>
    <input type="text" :placeholder="'Actor fullname'" class="item-input" v-model="actor.name" @input="'update:modelValue', $event.target.value"/>
  </p>
  <p>
    <input type="text" :placeholder="'Role'" class="item-input" v-model="actor.role" @input="'update:modelValue', $event.target.value"/>
  </p>
</template>

<script>
import {computed} from "vue";

export default {
  name: "ItemForListUpdate",
  props: {
    idActor: {},
    actorModel:{},
  },

  setup(props){
    const actor = computed(() => props.actorModel)

    return{
      actor
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