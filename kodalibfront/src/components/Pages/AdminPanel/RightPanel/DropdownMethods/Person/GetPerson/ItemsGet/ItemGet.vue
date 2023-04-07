<template>
  <p class="item-box">
    <span class="item-name">{{ itemName }}: </span>
    <span class="item">{{ item }}</span>
  </p>


</template>

<script>
export default {
  name: "ItemGet",
  props: {
    item: {},
    itemName: {}
  }
}
</script>

<style scoped>
.item {
  font-size: 20px;
  color: #4e3883;
  max-width: 980px;
  padding-left: 10px;
  word-break: break-all;
}

.item-name {
  font-size: 20px;
  height: 100%;
}

.item-box{
  max-width: 990px;
  line-height: 30px;
  margin-top: 20px;
  padding: 10px;
  border-left: 2px solid #4e3883;
  height: 100%;
  display: flex;
}

</style>