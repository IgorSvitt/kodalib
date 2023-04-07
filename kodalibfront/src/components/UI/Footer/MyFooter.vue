<template>
  <footer>
    <div class="container">
      <div class="footer-titles">
        <span>© 2023, Kodalib</span>
        <a href="mailto:kodalib@proton.me" class="email">kodalib@proton.me</a>
      </div>
      <div>
        <hr>
      </div>
    </div>
  </footer>
</template>

<script>
export default {
  name: "MyFooter"
}
</script>

<style scoped>
footer {
  height: 140px;
  width: 100%;
  background-color: #4e3883;
}

.footer-titles{
  display: flex;
  justify-content:space-around;
  font-size: 26px;
  font-weight: 400;
  padding-top: 20px;
  color: #efefef;
  margin-bottom: 10px;
}

.email{
  color: #efefef;
}

.email:hover{
  border-bottom: 1px solid #efefef;
  opacity: 0.7;
}

hr{
  height: 2px;
  background: linear-gradient(90deg, rgba(255,221,204,1) 0%, rgba(239,239,239,1) 100%);
}


@media (max-width: 752px) {
  .footer-titles{
    font-size: 16px;
  }
  hr{
    height: 0.02px;
  }
}
</style>