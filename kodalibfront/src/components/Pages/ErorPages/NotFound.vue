<template>
<div class="not-found">
  <h1 class="not-found-text">NOT FOUND </h1>
  <img class="not-found-img" src="https://www.meme-arsenal.com/memes/af4e0fc338ee32050ba6e377135b1033.jpg">
</div>
</template>

<script>
export default {
  name: "NotFound"
}
</script>

<style scoped>

.not-found{
  width: 100%;
  height: 100%;
  font-size: 50px;
}
.not-found-text{
  color: #fff;
  position: absolute;
  top: 50%;
  left: 30%;
}

.not-found-img{
  width: 100%;
}

</style>