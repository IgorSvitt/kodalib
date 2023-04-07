<template>
  <div>
    <img :src="image" class="info-img">
  </div>
</template>

<script>
export default {
  name: "LeftInformation",
  props:{
    image:{
      type: String
    }
  }
}
</script>

<style scoped>
.info-img {
  width: 310px;
  height: 460px;
  object-position: top center;
  object-fit: cover;
}
</style>