// micro-C example 9 -- return a result via a pointer argument

Int t;

void main(Int i) {
  Int r;
  fac(i, &r);
  print r;
}

void fac(Int n, Int *res) {
  // print &n;			// Show n's address
  if (n == 0)
    *res = 1;
  else {
    Int tmp;
    fac(n - 1, &tmp);
    *res = tmp * n;
  }
}
