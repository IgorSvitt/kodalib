<template>
  <div class="left-panel">
    <dropdown-panel></dropdown-panel>
  </div>
</template>

<script>
import DropdownPanel from './Dropdown/DropdownPanel.vue';

export default {
  components: { DropdownPanel },
    name: "left-panel",
  setup(){
  }
};
</script>

<style scoped>
.left-panel {
  background-color: #503883;
  width: 200px;
}

.database{
  margin-top: 20px;
  display: block;
  text-align: center;
  margin-bottom: 30px;
}

.table{
  display: block;
  text-align: center;
}

.btn-db{
  margin-top: 10px;
  border: #392661 solid 1px;
  background-color: #ffb996;
  padding: 10px;
  border-radius: 20px;
  font-size: 14px;
  cursor: pointer;
}

.input-db{
  border: none;
  border-radius: 20px;
  padding: 5px 10px;
}

.red{
  background-color: red;
}
</style>