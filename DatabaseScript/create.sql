--
-- PostgreSQL database dump
--

-- Dumped from database version 9.5.2
-- Dumped by pg_dump version 9.5.2

-- Started on 2017-01-20 13:02:38

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE workproject;
--
-- TOC entry 2790 (class 1262 OID 17949)
-- Name: workproject; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE workproject WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Russian_Russia.1251' LC_CTYPE = 'Russian_Russia.1251';


ALTER DATABASE workproject OWNER TO postgres;

\connect workproject

SET statement_timeout = 0;
SET lock_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 7 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: postgres
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO postgres;

--
-- TOC entry 2791 (class 0 OID 0)
-- Dependencies: 7
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: postgres
--

COMMENT ON SCHEMA public IS 'standard public schema';


--
-- TOC entry 1 (class 3079 OID 12355)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2793 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


SET search_path = public, pg_catalog;

--
-- TOC entry 637 (class 1247 OID 17950)
-- Name: added_tax_value; Type: DOMAIN; Schema: public; Owner: postgres
--

CREATE DOMAIN added_tax_value AS smallint NOT NULL DEFAULT 0
	CONSTRAINT check_added_tax_value CHECK (((VALUE = 0) OR (VALUE = 10) OR (VALUE = 18)));


ALTER DOMAIN added_tax_value OWNER TO postgres;

--
-- TOC entry 639 (class 1247 OID 17953)
-- Name: alignment; Type: TYPE; Schema: public; Owner: postgres
--

CREATE TYPE alignment AS ENUM (
    'not_set',
    'top_left',
    'top_center',
    'top_right',
    'middle_left',
    'middle_center',
    'middle_right',
    'bottom_left',
    'bottom_center',
    'bottom_right'
);


ALTER TYPE alignment OWNER TO postgres;

--
-- TOC entry 642 (class 1247 OID 17974)
-- Name: article_calculation; Type: TYPE; Schema: public; Owner: postgres
--

CREATE TYPE article_calculation AS ENUM (
    'content',
    'cost',
    'profit',
    'other',
    'price',
    'tax',
    'summa'
);


ALTER TYPE article_calculation OWNER TO postgres;

--
-- TOC entry 645 (class 1247 OID 17990)
-- Name: article_content; Type: TYPE; Schema: public; Owner: postgres
--

CREATE TYPE article_content AS ENUM (
    'material',
    'operation',
    'product',
    'tax',
    'none'
);


ALTER TYPE article_content OWNER TO postgres;

--
-- TOC entry 648 (class 1247 OID 18002)
-- Name: autosize_mode; Type: TYPE; Schema: public; Owner: postgres
--

CREATE TYPE autosize_mode AS ENUM (
    'not_set',
    'none',
    'all_cells',
    'all_cells_except_header',
    'displayed_cells',
    'displayed_cells_except_header',
    'column_header',
    'fill'
);


ALTER TYPE autosize_mode OWNER TO postgres;

--
-- TOC entry 651 (class 1247 OID 18020)
-- Name: calculation_method; Type: TYPE; Schema: public; Owner: postgres
--

CREATE TYPE calculation_method AS ENUM (
    'profit',
    'price'
);


ALTER TYPE calculation_method OWNER TO postgres;

--
-- TOC entry 2794 (class 0 OID 0)
-- Dependencies: 651
-- Name: TYPE calculation_method; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TYPE calculation_method IS 'Вариант расчета себестоимости:
- profit - расчет прибыли от себестоимости
- price - расчет процента прибыли как разницы между цена и себестоимостью';


--
-- TOC entry 654 (class 1247 OID 18026)
-- Name: employee_status; Type: TYPE; Schema: public; Owner: postgres
--

CREATE TYPE employee_status AS ENUM (
    'undefined',
    'general',
    'chief_accountant',
    'employee',
    'worker'
);


ALTER TYPE employee_status OWNER TO postgres;

--
-- TOC entry 657 (class 1247 OID 18037)
-- Name: invoice_direction; Type: DOMAIN; Schema: public; Owner: postgres
--

CREATE DOMAIN invoice_direction AS integer NOT NULL DEFAULT 0
	CONSTRAINT check_invoice_direction CHECK (((VALUE >= '-1'::integer) AND (VALUE <= 1)));


ALTER DOMAIN invoice_direction OWNER TO postgres;

--
-- TOC entry 243 (class 1255 OID 18039)
-- Name: calculate_price_operation(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION calculate_price_operation() RETURNS trigger
    LANGUAGE plpgsql
    AS $$declare
   calc_price boolean;
begin
   if (new.time_rate = 0) then
      return new;
   end if;
	
   calc_price := false;
   if (tg_op = 'INSERT') then
      if (new.price = 0) then
         calc_price := true;
      end if;
   else
      if ((new.salary != old.salary or new.time_rate != old.time_rate ) and (new.price = old.price)) then
         calc_price := true;
      end if;
   end if;
   if (calc_price = true) then
      new.price := new.salary::numeric(8,3) / new.time_rate;
   end if;
	
   return new;
END;$$;


ALTER FUNCTION public.calculate_price_operation() OWNER TO postgres;

--
-- TOC entry 2795 (class 0 OID 0)
-- Dependencies: 243
-- Name: FUNCTION calculate_price_operation(); Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON FUNCTION calculate_price_operation() IS 'Расчет цены технологической операции в зависимости от зар. платы и нормы выработки';


--
-- TOC entry 258 (class 1255 OID 18040)
-- Name: calculate_price_specification(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION calculate_price_specification() RETURNS trigger
    LANGUAGE plpgsql
    AS $$begin
   if (new.calc_price_method = 'profit'::calculation_method) then
      new.profit := new.cost * new.profit_percent / 100;
      new.price := new.cost + new.profit;
   else
      new.profit := new.price - new.cost;
      new.profit_percent := (new.profit / new.price) * 100;
   end if;

   if (tg_op = 'INSERT') then
      if (new.tax_summa = 0::money) then
         new.tax_summa := new.price * new.tax_value / 100;
      end if;

      if (new.summa = 0::money) then
         new.summa := new.price + new.tax_summa;
      end if;
   else
      if ((new.price != old.price or new.tax_value != old.tax_value) and new.tax_summa = old.tax_summa) then
         new.tax_summa := new.price * new.tax_value / 100;
      end if;

      if (new.tax_summa != old.tax_summa and new.summa = old.summa) then
         new.summa := new.price + new.tax_summa;
      end if;
   end if;

   return new;
end;$$;


ALTER FUNCTION public.calculate_price_specification() OWNER TO postgres;

--
-- TOC entry 2796 (class 0 OID 0)
-- Dependencies: 258
-- Name: FUNCTION calculate_price_specification(); Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON FUNCTION calculate_price_specification() IS 'Расчет прибыли, нормы прибыли цены спецификации и обновление цены изделия';


--
-- TOC entry 259 (class 1255 OID 18041)
-- Name: check_group(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION check_group() RETURNS trigger
    LANGUAGE plpgsql
    AS $$declare
   table_name character varying(25);
   table_title character varying(50);
   group_name character varying(25);
begin
   if new.group_id is null then
      return new;
   end if;
   
   select table_property.name, group_item.name
      into table_name, group_name
      from table_property, group_item
      where group_item.table_id = table_property.id and group_item.id = new.group_id;

   if (tg_table_name != table_name) then
      select table_property.title
         into table_title
         from table_property
         where table_property.name = tg_table_name;
      raise exception 'Группа (%) не принадлежит таблице (%)', group_name, table_title;
   end if;

   return new;
end;$$;


ALTER FUNCTION public.check_group() OWNER TO postgres;

--
-- TOC entry 260 (class 1255 OID 18042)
-- Name: check_item_product_specification(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION check_item_product_specification() RETURNS trigger
    LANGUAGE plpgsql
    AS $$declare
   p1 integer;
   p2 integer;
begin
   select specification.product_id
      into p1
      from specification
      where specification.id = new.element_id;

   select specification.product_id
      into p2
      from specification
      where specification.id = new.specification_id;

   if (p1 != p2) then
      RAISE EXCEPTION 'Product specification may not contain the same product';
   end if;

   return new;
end;$$;


ALTER FUNCTION public.check_item_product_specification() OWNER TO postgres;

--
-- TOC entry 261 (class 1255 OID 18043)
-- Name: clear_default_measurement(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION clear_default_measurement() RETURNS trigger
    LANGUAGE plpgsql
    AS $$begin
   if (new.is_default and ((tg_op = 'INSERT') or (new.is_default != old.is_default))) then
      update measurement
         set is_default = false
         where measurement.is_default = true;
   end if;

   return new;
end;$$;


ALTER FUNCTION public.clear_default_measurement() OWNER TO postgres;

--
-- TOC entry 262 (class 1255 OID 18044)
-- Name: clear_default_specification(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION clear_default_specification() RETURNS trigger
    LANGUAGE plpgsql
    AS $$begin
   if (tg_op = 'INSERT' or new.is_default != old.is_default) then
      if (new.is_default) then
         update specification
            set is_default = false
            where specification.is_default = true and specification.product_id = new.product_id;
      else
         if (tg_op != 'INSERT') then
            update product
               set specification_id = null
               where product.id = new.product_id;
         end if;
      end if;
   end if;

   return new;
end;$$;


ALTER FUNCTION public.clear_default_specification() OWNER TO postgres;

--
-- TOC entry 263 (class 1255 OID 18045)
-- Name: create_default_material_detail(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION create_default_material_detail() RETURNS trigger
    LANGUAGE plpgsql
    AS $$begin
   INSERT INTO material_detail (name, material_id) VALUES ('Основной', new.id);
   return new;
end;$$;


ALTER FUNCTION public.create_default_material_detail() OWNER TO postgres;

--
-- TOC entry 264 (class 1255 OID 18046)
-- Name: define_material_price(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION define_material_price() RETURNS trigger
    LANGUAGE plpgsql
    AS $$declare
   price money;
   id_material integer;
begin
   if (new.price = 0::money or (new.price is null)) then
      select material.price
         into price
         from material
         where material.id = new.material_id;
      new.price := price;
   end if;

   return new;
end;$$;


ALTER FUNCTION public.define_material_price() OWNER TO postgres;

--
-- TOC entry 265 (class 1255 OID 18047)
-- Name: get_control_sum(integer[], integer[]); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION get_control_sum(source integer[], coeff integer[]) RETURNS integer
    LANGUAGE plpgsql
    AS $$declare
   sum integer;
   m integer;
begin
   m := min_int(array_length(source, 1), array_length(coeff, 1));

   sum := 0;
   for i in 1 .. m loop
      sum := sum + source[i] * coeff[i];
   end loop;
	
   return sum;
end;$$;


ALTER FUNCTION public.get_control_sum(source integer[], coeff integer[]) OWNER TO postgres;

--
-- TOC entry 266 (class 1255 OID 18048)
-- Name: get_control_value(integer[], integer[], integer, boolean); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION get_control_value(source integer[], coeff integer[], divider integer, test10 boolean DEFAULT true) RETURNS integer
    LANGUAGE plpgsql
    AS $$declare
   r integer;
begin
   r := get_control_sum(source, coeff) % divider;
   if (test10 and r = 10) then
      r := 0;
   end if;

   return r;
end;$$;


ALTER FUNCTION public.get_control_value(source integer[], coeff integer[], divider integer, test10 boolean) OWNER TO postgres;

--
-- TOC entry 267 (class 1255 OID 18049)
-- Name: min_int(integer, integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION min_int(left_value integer, right_value integer) RETURNS integer
    LANGUAGE plpgsql
    AS $$declare
   m integer;
begin
   if (left_value < right_value) then
      m = left_value;
   else
      m = right_value;
   end if;

   return m;
end;$$;


ALTER FUNCTION public.min_int(left_value integer, right_value integer) OWNER TO postgres;

--
-- TOC entry 268 (class 1255 OID 18050)
-- Name: set_price_item_material(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION set_price_item_material() RETURNS trigger
    LANGUAGE plpgsql
    AS $$declare
   price numeric(8, 3);
begin
   if (new.price = 0::money) then
      select material.price
         into price
         from material, material_detail
         where
            material_detail.id = new.element_id and
            material.id = material_detail.material_id;
      new.price := price::money;
   end if;

   if (new.summa = 0::money) then
      new.summa := (price * new.count_items)::money;
   end if;

   return new;
end;$$;


ALTER FUNCTION public.set_price_item_material() OWNER TO postgres;

--
-- TOC entry 2797 (class 0 OID 0)
-- Dependencies: 268
-- Name: FUNCTION set_price_item_material(); Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON FUNCTION set_price_item_material() IS 'Расчитывает цену и сумму нового элемента спецификации (материал)';


--
-- TOC entry 269 (class 1255 OID 18051)
-- Name: set_price_item_operation(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION set_price_item_operation() RETURNS trigger
    LANGUAGE plpgsql
    AS $$declare
   price numeric(8, 3);
begin
   if (new.price = 0::money) then
      select operation.price
         into price
         from operation
         where operation.id = new.element_id;
      new.price := price::money;
   end if;

   if (new.summa = 0::money) then
      new.summa := (price * new.count_items)::money;
   end if;

   return new;
end;$$;


ALTER FUNCTION public.set_price_item_operation() OWNER TO postgres;

--
-- TOC entry 2798 (class 0 OID 0)
-- Dependencies: 269
-- Name: FUNCTION set_price_item_operation(); Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON FUNCTION set_price_item_operation() IS 'Расчитывает цену и сумму нового элемента спецификации (операция)';


--
-- TOC entry 270 (class 1255 OID 18052)
-- Name: set_price_item_product(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION set_price_item_product() RETURNS trigger
    LANGUAGE plpgsql
    AS $$declare
   price money;
begin
   if (new.price = 0::money) then
      select specification.cost
         into price
         from specification
         where specification.id = new.element_id;
      new.price := price;
   end if;

   if (new.summa = 0::money) then
      new.summa := (price * new.count_items)::money;
   end if;

   return new;
end;$$;


ALTER FUNCTION public.set_price_item_product() OWNER TO postgres;

--
-- TOC entry 244 (class 1255 OID 18053)
-- Name: set_price_item_tax(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION set_price_item_tax() RETURNS trigger
    LANGUAGE plpgsql
    AS $$declare
	vtax numeric(6, 2);
	asum money;
begin
   if (new.count_items is null) then
      select tax.tax_value
         into vtax
         from tax
         where tax.id = new.element_id;
      if (vtax is not null) then
         new.count_items := vtax;
      else
         new.count_items := 0;
      end if;
	end if;

	if (new.summa = 0::money) then
      select sum(i.summa)
         into asum
         from
            item_specification as i
         where
            i.article_id = new.source_id and
            i.specification_id = new.specification_id;
      if (asum is not null) then
		     new.summa := (new.count_items * asum::numeric(15, 3) / 100)::money;
		  end if;
	end if;

	return new;
end;$$;


ALTER FUNCTION public.set_price_item_tax() OWNER TO postgres;

--
-- TOC entry 257 (class 1255 OID 18054)
-- Name: test_account(integer[]); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION test_account(account integer[]) RETURNS boolean
    LANGUAGE plpgsql
    AS $$declare
   k integer[] := '{ 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1, 3, 7, 1 }';
   sum integer;
begin
   if (array_length(account, 1) != 23) then
      return false;
   end if;

   sum := get_control_sum(account, k);
   return sum % 10 = 0;
end;$$;


ALTER FUNCTION public.test_account(account integer[]) OWNER TO postgres;

--
-- TOC entry 241 (class 1255 OID 18055)
-- Name: test_bank_account(numeric, numeric); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION test_bank_account(account numeric, bik numeric) RETURNS boolean
    LANGUAGE plpgsql
    AS $$declare
   bik_a integer[];
   account_a integer[];
begin
   bik_a = string_to_array('0' || substring(lpad(bik::character varying, 9, '0') from 5 for 2), NULL)::integer[];
   account_a = string_to_array(account::character varying, NULL)::integer[];
   return test_account(bik_a || account_a);
end;$$;


ALTER FUNCTION public.test_bank_account(account numeric, bik numeric) OWNER TO postgres;

--
-- TOC entry 242 (class 1255 OID 18056)
-- Name: test_bank_codes(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION test_bank_codes() RETURNS trigger
    LANGUAGE plpgsql
    AS $$begin
   if (not test_bank_account(new.account, new.bik)) then
      raise exception 'Некорректное значение БИК или корр. счета';
   end if;

   return new;
end;$$;


ALTER FUNCTION public.test_bank_codes() OWNER TO postgres;

--
-- TOC entry 271 (class 1255 OID 18057)
-- Name: test_contractor_codes(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION test_contractor_codes() RETURNS trigger
    LANGUAGE plpgsql
    AS $$declare
   bik numeric(9,0);
begin
   if ((new.inn > 0) and (not test_inn(new.inn))) then
      raise exception 'Некорректное значение ИНН';
   end if;

   if ((new.okpo is not null) and (not test_okpo(new.okpo))) then
      raise exception 'Некорректное значение ОКПО';
   end if;

   if ((new.bank_id is not null) and (new.account is not null)) then
      select bank.bik
         into bik
         from bank 
         where bank.id = new.bank_id;
      if (not test_current_account(new.account, bik)) then
         raise exception 'Некорректное значение расч. счета';
      end if;
   end if;

   return new;
end;$$;


ALTER FUNCTION public.test_contractor_codes() OWNER TO postgres;

--
-- TOC entry 272 (class 1255 OID 18058)
-- Name: test_current_account(numeric, numeric); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION test_current_account(account numeric, bik numeric) RETURNS boolean
    LANGUAGE plpgsql
    AS $$declare
   bik_a integer[];
   account_a integer[];
begin
   bik_a = string_to_array((bik % 1000)::character varying, NULL)::integer[];
   account_a = string_to_array(account::character varying, NULL)::integer[];
   return test_account(bik_a || account_a);
end;$$;


ALTER FUNCTION public.test_current_account(account numeric, bik numeric) OWNER TO postgres;

--
-- TOC entry 273 (class 1255 OID 18059)
-- Name: test_inn(numeric); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION test_inn(inn_value numeric) RETURNS boolean
    LANGUAGE plpgsql
    AS $$declare
   inn_arr integer[];
   k integer[] := '{ 2, 4, 10, 3, 5, 9, 4, 6, 8 }';
   k1 integer[] := '{ 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 }';
   k2 integer[] := '{3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 }';
begin
   inn_arr := string_to_array(inn_value::character varying, NULL)::integer[];

   if (array_length(inn_arr, 1) != 10 and array_length(inn_arr, 1) != 12) then
      return false;
   end if;

   if (get_control_value(inn_arr, k, 11) = inn_arr[10]) then
      if (array_length(inn_arr, 1) = 12) then
         return get_control_value(inn_arr, k1, 11) == inn_arr[11] && get_control_value(inn_arr, k2, 11) == inn_arr[12];
      end if;
		
      return true;
   end if;

   return false;
end;$$;


ALTER FUNCTION public.test_inn(inn_value numeric) OWNER TO postgres;

--
-- TOC entry 274 (class 1255 OID 18060)
-- Name: test_okpo(numeric); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION test_okpo(okpo_value numeric) RETURNS boolean
    LANGUAGE plpgsql
    AS $$declare
   okpo_arr integer[];
   k1 integer[] := '{ 1, 2, 3, 4, 5, 6, 7 }';
   k2 integer[] := '{ 3, 4, 5, 6, 7, 8, 9 }';
   c integer;
begin
   okpo_arr := string_to_array(okpo_value::character varying, NULL)::integer[];
   if (array_length(okpo_arr, 1) < 8) then
      return false;
   end if;
	
   c := get_control_value(okpo_arr, k1, 11, false);
   if (c > 9) then
      c := get_control_value(okpo_arr, k2, 11);
   end if;

   return c = okpo_arr[8];
end;$$;


ALTER FUNCTION public.test_okpo(okpo_value numeric) OWNER TO postgres;

--
-- TOC entry 275 (class 1255 OID 18061)
-- Name: update_default_specification(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION update_default_specification() RETURNS trigger
    LANGUAGE plpgsql
    AS $$begin
   if (tg_op = 'INSERT' or new.is_default != old.is_default) then
      if (new.is_default) then
         update product
            set specification_id = new.id
            where product.id = new.product_id;
      end if;
   end if;

   return new;
end;$$;


ALTER FUNCTION public.update_default_specification() OWNER TO postgres;

--
-- TOC entry 276 (class 1255 OID 18062)
-- Name: update_document_summa(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION update_document_summa() RETURNS trigger
    LANGUAGE plpgsql
    AS $$declare
   doc_id integer;
begin
   if (tg_op = 'INSERT' or tg_op = 'UPDATE') then
      doc_id := new.document_id;
   else
      doc_id := old.document_id;
   end if;

   update document
      set summa = i.items_summa
      from
         (select sum(summa) as items_summa from item_document where document_id = doc_id) as i
      where id = doc_id;

   if (tg_op = 'DELETE') then
      return old;
   else
      return new;
   end if;
end;$$;


ALTER FUNCTION public.update_document_summa() OWNER TO postgres;

--
-- TOC entry 277 (class 1255 OID 18063)
-- Name: update_specification_price(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION update_specification_price() RETURNS trigger
    LANGUAGE plpgsql
    AS $$declare
   a_id integer;
   s_id integer;
begin
   if (tg_op = 'INSERT' or tg_op = 'UPDATE') then
      a_id := new.article_id;
      s_id := new.specification_id;
   else
      a_id := old.article_id;
      s_id := old.specification_id;
   end if;

   update specification
      set cost = i.items_summa
      from
         (select sum(summa) as items_summa from item_specification where specification_id = s_id) as i
      where id = s_id;

   if (tg_table_name != 'item_tax') then
      update item_tax
         set summa = (item_tax.count_items * i.items_summa::numeric(15, 3) / 100)::money
         from
           (select sum(sp.summa) as items_summa
               from item_specification as sp
               where
                  sp.article_id = a_id and
                  sp.specification_id = s_id) as i
         where
            item_tax.source_id = a_id and
            item_tax.specification_id = s_id;
   end if;

   if (tg_op = 'DELETE') then
      return old;
   else
      return new;
   end if;
end;$$;


ALTER FUNCTION public.update_specification_price() OWNER TO postgres;

--
-- TOC entry 2799 (class 0 OID 0)
-- Dependencies: 277
-- Name: FUNCTION update_specification_price(); Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON FUNCTION update_specification_price() IS 'Обновление себестоимости спецификации при измене';


--
-- TOC entry 278 (class 1255 OID 18064)
-- Name: update_summa(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION update_summa() RETURNS trigger
    LANGUAGE plpgsql
    AS $$begin
   if (((new.price != old.price) or (new.count_items != old.count_items)) and (new.summa = old.summa)) then
      new.summa := new.price * new.count_items;
   end if;

   return new;
end;$$;


ALTER FUNCTION public.update_summa() OWNER TO postgres;

--
-- TOC entry 2800 (class 0 OID 0)
-- Dependencies: 278
-- Name: FUNCTION update_summa(); Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON FUNCTION update_summa() IS 'Изменение суммы строки таблицы при изменении количества или цены';


--
-- TOC entry 279 (class 1255 OID 18065)
-- Name: update_tax_summa_item(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION update_tax_summa_item() RETURNS trigger
    LANGUAGE plpgsql
    AS $$declare
  asum money;
begin
   if (((new.count_items != old.count_items) and (new.summa = old.summa)) or (new.source_id != old.source_id)) then
      select sum(i.summa)
         into asum
         from item_specification as i
         where
            i.article_id = new.source_id and
            i.specification_id = new.specification_id;
		new.summa :=(new.count_items * asum::numeric(15, 3) / 100)::money;
  end if;

  return new;
end;$$;


ALTER FUNCTION public.update_tax_summa_item() OWNER TO postgres;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 181 (class 1259 OID 18066)
-- Name: article; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE article (
    id integer NOT NULL,
    name character varying(100) NOT NULL,
    code integer NOT NULL,
    content article_content DEFAULT 'none'::article_content NOT NULL,
    calculation article_calculation DEFAULT 'other'::article_calculation NOT NULL,
    printable boolean DEFAULT true NOT NULL,
    items_printable boolean DEFAULT false NOT NULL,
    bolded boolean DEFAULT false NOT NULL,
    print_zero_value boolean DEFAULT false NOT NULL
);


ALTER TABLE article OWNER TO postgres;

--
-- TOC entry 2801 (class 0 OID 0)
-- Dependencies: 181
-- Name: TABLE article; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE article IS 'Список статей калькуляции';


--
-- TOC entry 182 (class 1259 OID 18074)
-- Name: article_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE article_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE article_id_seq OWNER TO postgres;

--
-- TOC entry 2802 (class 0 OID 0)
-- Dependencies: 182
-- Name: article_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE article_id_seq OWNED BY article.id;


--
-- TOC entry 183 (class 1259 OID 18076)
-- Name: bank; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE bank (
    id integer NOT NULL,
    name character varying(100) NOT NULL,
    bik numeric(9,0) NOT NULL,
    account numeric(20,0) NOT NULL
);


ALTER TABLE bank OWNER TO postgres;

--
-- TOC entry 2803 (class 0 OID 0)
-- Dependencies: 183
-- Name: TABLE bank; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE bank IS 'Банки';


--
-- TOC entry 184 (class 1259 OID 18079)
-- Name: bank_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE bank_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE bank_id_seq OWNER TO postgres;

--
-- TOC entry 2804 (class 0 OID 0)
-- Dependencies: 184
-- Name: bank_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE bank_id_seq OWNED BY bank.id;


--
-- TOC entry 185 (class 1259 OID 18081)
-- Name: column_item; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE column_item (
    id integer NOT NULL,
    name character varying(25) NOT NULL,
    header character varying(100),
    width integer DEFAULT 100 NOT NULL,
    mode autosize_mode DEFAULT 'not_set'::autosize_mode NOT NULL,
    fill_weight integer DEFAULT 100 NOT NULL,
    alignment alignment DEFAULT 'not_set'::alignment NOT NULL,
    format character varying(25),
    hide_on_group boolean DEFAULT false NOT NULL,
    index integer DEFAULT 0 NOT NULL,
    table_id integer NOT NULL,
    visible boolean DEFAULT true NOT NULL,
    source_id integer,
    frozen boolean DEFAULT false NOT NULL,
    sorted integer DEFAULT 0 NOT NULL
);


ALTER TABLE column_item OWNER TO postgres;

--
-- TOC entry 186 (class 1259 OID 18093)
-- Name: column_item_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE column_item_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE column_item_id_seq OWNER TO postgres;

--
-- TOC entry 2805 (class 0 OID 0)
-- Dependencies: 186
-- Name: column_item_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE column_item_id_seq OWNED BY column_item.id;


--
-- TOC entry 187 (class 1259 OID 18095)
-- Name: contractor; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE contractor (
    id integer NOT NULL,
    name character varying(50) NOT NULL,
    short_name character varying(50) NOT NULL,
    full_name character varying(100),
    okopf_id integer,
    inn numeric(12,0),
    kpp numeric(9,0) DEFAULT 0 NOT NULL,
    ogrn numeric(13,0) DEFAULT 0,
    address character varying(250),
    phone character varying(30),
    fax character varying(18),
    email character varying(100),
    web character varying(100),
    okpo numeric(8,0),
    account numeric(20,0),
    bank_id integer,
    our_firm boolean DEFAULT false NOT NULL,
    group_id integer
);


ALTER TABLE contractor OWNER TO postgres;

--
-- TOC entry 2806 (class 0 OID 0)
-- Dependencies: 187
-- Name: TABLE contractor; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE contractor IS 'Контрагенты';


--
-- TOC entry 188 (class 1259 OID 18105)
-- Name: contractor_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE contractor_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE contractor_id_seq OWNER TO postgres;

--
-- TOC entry 2807 (class 0 OID 0)
-- Dependencies: 188
-- Name: contractor_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE contractor_id_seq OWNED BY contractor.id;


--
-- TOC entry 189 (class 1259 OID 18107)
-- Name: document_common; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE document_common (
    id integer NOT NULL,
    accept boolean DEFAULT true NOT NULL,
    date_created timestamp without time zone DEFAULT now()
);


ALTER TABLE document_common OWNER TO postgres;

--
-- TOC entry 2808 (class 0 OID 0)
-- Dependencies: 189
-- Name: TABLE document_common; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE document_common IS 'Описание общих свойств всех документов';


--
-- TOC entry 190 (class 1259 OID 18112)
-- Name: document; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE document (
    reference_number integer NOT NULL,
    summa money DEFAULT 0 NOT NULL,
    organization_id integer
)
INHERITS (document_common);


ALTER TABLE document OWNER TO postgres;

--
-- TOC entry 2809 (class 0 OID 0)
-- Dependencies: 190
-- Name: TABLE document; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE document IS 'Документы имеющие номер';


--
-- TOC entry 191 (class 1259 OID 18118)
-- Name: document_common_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE document_common_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE document_common_id_seq OWNER TO postgres;

--
-- TOC entry 2810 (class 0 OID 0)
-- Dependencies: 191
-- Name: document_common_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE document_common_id_seq OWNED BY document_common.id;


--
-- TOC entry 192 (class 1259 OID 18120)
-- Name: employee; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE employee (
    id integer NOT NULL,
    contractor_id integer NOT NULL,
    person_id integer NOT NULL,
    post_id integer,
    phone character varying(30),
    email character varying(100),
    status employee_status DEFAULT 'undefined'::employee_status NOT NULL,
    fax character varying(30)
);


ALTER TABLE employee OWNER TO postgres;

--
-- TOC entry 2811 (class 0 OID 0)
-- Dependencies: 192
-- Name: TABLE employee; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE employee IS 'Служащие';


--
-- TOC entry 193 (class 1259 OID 18124)
-- Name: employee_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE employee_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE employee_id_seq OWNER TO postgres;

--
-- TOC entry 2812 (class 0 OID 0)
-- Dependencies: 193
-- Name: employee_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE employee_id_seq OWNED BY employee.id;


--
-- TOC entry 194 (class 1259 OID 18126)
-- Name: group_item; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE group_item (
    id integer NOT NULL,
    name character varying(25) NOT NULL,
    table_id integer NOT NULL,
    parent_id integer
);


ALTER TABLE group_item OWNER TO postgres;

--
-- TOC entry 195 (class 1259 OID 18129)
-- Name: group_item_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE group_item_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE group_item_id_seq OWNER TO postgres;

--
-- TOC entry 2813 (class 0 OID 0)
-- Dependencies: 195
-- Name: group_item_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE group_item_id_seq OWNED BY group_item.id;


--
-- TOC entry 196 (class 1259 OID 18131)
-- Name: image; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE image (
    id integer NOT NULL,
    source character varying(256),
    name character varying(64) NOT NULL
);


ALTER TABLE image OWNER TO postgres;

--
-- TOC entry 197 (class 1259 OID 18134)
-- Name: image_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE image_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE image_id_seq OWNER TO postgres;

--
-- TOC entry 2814 (class 0 OID 0)
-- Dependencies: 197
-- Name: image_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE image_id_seq OWNED BY image.id;


--
-- TOC entry 198 (class 1259 OID 18136)
-- Name: invoice; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE invoice (
    direction invoice_direction
)
INHERITS (document);


ALTER TABLE invoice OWNER TO postgres;

--
-- TOC entry 2815 (class 0 OID 0)
-- Dependencies: 198
-- Name: TABLE invoice; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE invoice IS 'Документы определяющие тип документа как входящий или исходящий';


--
-- TOC entry 199 (class 1259 OID 18142)
-- Name: invoice_contractor; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE invoice_contractor (
    contractor_id integer NOT NULL
)
INHERITS (invoice);


ALTER TABLE invoice_contractor OWNER TO postgres;

--
-- TOC entry 2816 (class 0 OID 0)
-- Dependencies: 199
-- Name: TABLE invoice_contractor; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE invoice_contractor IS 'Накладные имеющие атрибут "Контрагент"';


--
-- TOC entry 200 (class 1259 OID 18148)
-- Name: invoice_expense; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE invoice_expense (
)
INHERITS (invoice_contractor);


ALTER TABLE invoice_expense OWNER TO postgres;

--
-- TOC entry 2817 (class 0 OID 0)
-- Dependencies: 200
-- Name: TABLE invoice_expense; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE invoice_expense IS 'Расходные накладные';


--
-- TOC entry 201 (class 1259 OID 18154)
-- Name: invoice_income; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE invoice_income (
)
INHERITS (invoice_contractor);


ALTER TABLE invoice_income OWNER TO postgres;

--
-- TOC entry 2818 (class 0 OID 0)
-- Dependencies: 201
-- Name: TABLE invoice_income; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE invoice_income IS 'Приходные накладные';


--
-- TOC entry 202 (class 1259 OID 18160)
-- Name: invoice_write_off; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE invoice_write_off (
)
INHERITS (invoice);


ALTER TABLE invoice_write_off OWNER TO postgres;

--
-- TOC entry 2819 (class 0 OID 0)
-- Dependencies: 202
-- Name: TABLE invoice_write_off; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE invoice_write_off IS 'Списание материалов';


--
-- TOC entry 203 (class 1259 OID 18166)
-- Name: item; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE item (
    id integer NOT NULL,
    element_id integer NOT NULL,
    price money DEFAULT 0 NOT NULL,
    count_items numeric(10,3) NOT NULL,
    summa money DEFAULT 0 NOT NULL
);


ALTER TABLE item OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 18171)
-- Name: item_document; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE item_document (
    document_id integer NOT NULL
)
INHERITS (item);


ALTER TABLE item_document OWNER TO postgres;

--
-- TOC entry 205 (class 1259 OID 18176)
-- Name: item_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE item_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE item_id_seq OWNER TO postgres;

--
-- TOC entry 2820 (class 0 OID 0)
-- Dependencies: 205
-- Name: item_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE item_id_seq OWNED BY item.id;


--
-- TOC entry 240 (class 1259 OID 18814)
-- Name: item_invoice_expense; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE item_invoice_expense (
)
INHERITS (item_document);


ALTER TABLE item_invoice_expense OWNER TO postgres;

--
-- TOC entry 2821 (class 0 OID 0)
-- Dependencies: 240
-- Name: TABLE item_invoice_expense; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE item_invoice_expense IS 'Материалы израсходованные согласно расходным накладным';


--
-- TOC entry 239 (class 1259 OID 18777)
-- Name: item_invoice_income; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE item_invoice_income (
)
INHERITS (item_document);


ALTER TABLE item_invoice_income OWNER TO postgres;

--
-- TOC entry 2822 (class 0 OID 0)
-- Dependencies: 239
-- Name: TABLE item_invoice_income; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE item_invoice_income IS 'Материалы поступившие согласно приходным накладным';


--
-- TOC entry 206 (class 1259 OID 18178)
-- Name: item_specification; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE item_specification (
    article_id integer NOT NULL,
    specification_id integer NOT NULL
)
INHERITS (item);


ALTER TABLE item_specification OWNER TO postgres;

--
-- TOC entry 207 (class 1259 OID 18183)
-- Name: item_material; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE item_material (
)
INHERITS (item_specification);


ALTER TABLE item_material OWNER TO postgres;

--
-- TOC entry 2823 (class 0 OID 0)
-- Dependencies: 207
-- Name: TABLE item_material; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE item_material IS 'Материалы содержащиеся в спецификациях';


--
-- TOC entry 208 (class 1259 OID 18188)
-- Name: item_operation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE item_operation (
)
INHERITS (item_specification);


ALTER TABLE item_operation OWNER TO postgres;

--
-- TOC entry 209 (class 1259 OID 18193)
-- Name: item_product; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE item_product (
    CONSTRAINT chk_item_specification CHECK ((specification_id <> element_id))
)
INHERITS (item_specification);


ALTER TABLE item_product OWNER TO postgres;

--
-- TOC entry 210 (class 1259 OID 18199)
-- Name: item_proposal; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE item_proposal (
)
INHERITS (item_document);


ALTER TABLE item_proposal OWNER TO postgres;

--
-- TOC entry 2824 (class 0 OID 0)
-- Dependencies: 210
-- Name: TABLE item_proposal; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE item_proposal IS 'Материалы содержащиеся в заявках';


--
-- TOC entry 211 (class 1259 OID 18204)
-- Name: item_tax; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE item_tax (
    source_id integer NOT NULL,
    CONSTRAINT chk_source_item_tax CHECK ((article_id <> source_id))
)
INHERITS (item_specification);


ALTER TABLE item_tax OWNER TO postgres;

--
-- TOC entry 2825 (class 0 OID 0)
-- Dependencies: 211
-- Name: COLUMN item_tax.source_id; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN item_tax.source_id IS 'Идентификатор статьи спецификации от которой расчитывается процент';


--
-- TOC entry 212 (class 1259 OID 18210)
-- Name: material; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE material (
    id integer NOT NULL,
    name character varying(100) NOT NULL,
    measurement_id integer,
    price money DEFAULT 0 NOT NULL,
    tax_value added_tax_value,
    service boolean DEFAULT false NOT NULL,
    begin_remainder numeric(15,3) DEFAULT 0 NOT NULL,
    min_order numeric(15,3) DEFAULT 0 NOT NULL,
    group_id integer,
    image_id integer,
    article_code character varying(50),
    alt_article_code character varying(50),
    has_details boolean DEFAULT false NOT NULL
);


ALTER TABLE material OWNER TO postgres;

--
-- TOC entry 2826 (class 0 OID 0)
-- Dependencies: 212
-- Name: TABLE material; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE material IS 'Материалы/услуги';


--
-- TOC entry 213 (class 1259 OID 18218)
-- Name: material_detail; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE material_detail (
    id integer NOT NULL,
    name character varying(50) NOT NULL,
    material_id integer NOT NULL
);


ALTER TABLE material_detail OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 18221)
-- Name: material_detail_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE material_detail_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE material_detail_id_seq OWNER TO postgres;

--
-- TOC entry 2827 (class 0 OID 0)
-- Dependencies: 214
-- Name: material_detail_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE material_detail_id_seq OWNED BY material_detail.id;


--
-- TOC entry 215 (class 1259 OID 18223)
-- Name: material_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE material_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE material_id_seq OWNER TO postgres;

--
-- TOC entry 2828 (class 0 OID 0)
-- Dependencies: 215
-- Name: material_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE material_id_seq OWNED BY material.id;


--
-- TOC entry 216 (class 1259 OID 18225)
-- Name: measurement; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE measurement (
    id integer NOT NULL,
    code integer NOT NULL,
    name character varying(100) NOT NULL,
    abbreviation character varying(10),
    is_default boolean DEFAULT false NOT NULL,
    CONSTRAINT chk_code_measurement CHECK ((code > 0))
);


ALTER TABLE measurement OWNER TO postgres;

--
-- TOC entry 2829 (class 0 OID 0)
-- Dependencies: 216
-- Name: TABLE measurement; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE measurement IS 'Еденицы измерений';


--
-- TOC entry 2830 (class 0 OID 0)
-- Dependencies: 216
-- Name: CONSTRAINT chk_code_measurement ON measurement; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON CONSTRAINT chk_code_measurement ON measurement IS 'Код еденицы измерения должен быть больше 0.';


--
-- TOC entry 217 (class 1259 OID 18230)
-- Name: measurement_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE measurement_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE measurement_id_seq OWNER TO postgres;

--
-- TOC entry 2831 (class 0 OID 0)
-- Dependencies: 217
-- Name: measurement_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE measurement_id_seq OWNED BY measurement.id;


--
-- TOC entry 218 (class 1259 OID 18232)
-- Name: numerator; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE numerator (
    id integer NOT NULL,
    name character varying(50) NOT NULL,
    document_number integer DEFAULT 1 NOT NULL
);


ALTER TABLE numerator OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 18236)
-- Name: numerator_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE numerator_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE numerator_id_seq OWNER TO postgres;

--
-- TOC entry 2832 (class 0 OID 0)
-- Dependencies: 219
-- Name: numerator_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE numerator_id_seq OWNED BY numerator.id;


--
-- TOC entry 220 (class 1259 OID 18238)
-- Name: okopf; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE okopf (
    id integer NOT NULL,
    code integer NOT NULL,
    name character varying(100) NOT NULL
);


ALTER TABLE okopf OWNER TO postgres;

--
-- TOC entry 2833 (class 0 OID 0)
-- Dependencies: 220
-- Name: TABLE okopf; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE okopf IS 'Общероссийский классифификатор организационно-правовых форм';


--
-- TOC entry 221 (class 1259 OID 18241)
-- Name: okopf_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE okopf_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE okopf_id_seq OWNER TO postgres;

--
-- TOC entry 2834 (class 0 OID 0)
-- Dependencies: 221
-- Name: okopf_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE okopf_id_seq OWNED BY okopf.id;


--
-- TOC entry 222 (class 1259 OID 18243)
-- Name: okpdtr; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE okpdtr (
    id integer NOT NULL,
    code numeric(12,0) NOT NULL,
    name character varying(100) NOT NULL,
    view_name character varying(50)
);


ALTER TABLE okpdtr OWNER TO postgres;

--
-- TOC entry 2835 (class 0 OID 0)
-- Dependencies: 222
-- Name: TABLE okpdtr; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE okpdtr IS 'Общероссийский классификатор профессий рабочих, должностей служащих и тарифных разрядов';


--
-- TOC entry 223 (class 1259 OID 18246)
-- Name: okpdtr_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE okpdtr_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE okpdtr_id_seq OWNER TO postgres;

--
-- TOC entry 2836 (class 0 OID 0)
-- Dependencies: 223
-- Name: okpdtr_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE okpdtr_id_seq OWNED BY okpdtr.id;


--
-- TOC entry 224 (class 1259 OID 18248)
-- Name: operation; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE operation (
    id integer NOT NULL,
    name character varying(100) NOT NULL,
    salary money DEFAULT 0 NOT NULL,
    time_rate integer DEFAULT 0 NOT NULL,
    price numeric(8,3) DEFAULT 0 NOT NULL,
    group_id integer
);


ALTER TABLE operation OWNER TO postgres;

--
-- TOC entry 2837 (class 0 OID 0)
-- Dependencies: 224
-- Name: TABLE operation; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE operation IS 'Технологичнские операции';


--
-- TOC entry 2838 (class 0 OID 0)
-- Dependencies: 224
-- Name: COLUMN operation.salary; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN operation.salary IS 'Заработная плата (часовая)';


--
-- TOC entry 2839 (class 0 OID 0)
-- Dependencies: 224
-- Name: COLUMN operation.time_rate; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN operation.time_rate IS 'Норма выработки (количество операций в час)';


--
-- TOC entry 2840 (class 0 OID 0)
-- Dependencies: 224
-- Name: COLUMN operation.price; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN operation.price IS 'Расценка за операцию';


--
-- TOC entry 225 (class 1259 OID 18254)
-- Name: operation_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE operation_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE operation_id_seq OWNER TO postgres;

--
-- TOC entry 2841 (class 0 OID 0)
-- Dependencies: 225
-- Name: operation_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE operation_id_seq OWNED BY operation.id;


--
-- TOC entry 226 (class 1259 OID 18256)
-- Name: person; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE person (
    id integer NOT NULL,
    name character varying(100) NOT NULL,
    first_name character varying(50) NOT NULL,
    middle_name character varying(50),
    surname character varying(50) NOT NULL,
    phone character varying(30),
    email character varying(50),
    group_id integer
);


ALTER TABLE person OWNER TO postgres;

--
-- TOC entry 2842 (class 0 OID 0)
-- Dependencies: 226
-- Name: TABLE person; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE person IS 'Физические лица';


--
-- TOC entry 2843 (class 0 OID 0)
-- Dependencies: 226
-- Name: COLUMN person.first_name; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN person.first_name IS 'Имя';


--
-- TOC entry 2844 (class 0 OID 0)
-- Dependencies: 226
-- Name: COLUMN person.middle_name; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN person.middle_name IS 'Отчество';


--
-- TOC entry 2845 (class 0 OID 0)
-- Dependencies: 226
-- Name: COLUMN person.surname; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN person.surname IS 'Фамилия';


--
-- TOC entry 227 (class 1259 OID 18259)
-- Name: person_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE person_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE person_id_seq OWNER TO postgres;

--
-- TOC entry 2846 (class 0 OID 0)
-- Dependencies: 227
-- Name: person_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE person_id_seq OWNED BY person.id;


--
-- TOC entry 228 (class 1259 OID 18261)
-- Name: product; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE product (
    id integer NOT NULL,
    name character varying(50) NOT NULL,
    article_code character varying(50),
    full_name character varying(120),
    specification_id integer
);


ALTER TABLE product OWNER TO postgres;

--
-- TOC entry 2847 (class 0 OID 0)
-- Dependencies: 228
-- Name: TABLE product; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE product IS 'Список изделий';


--
-- TOC entry 229 (class 1259 OID 18264)
-- Name: product_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE product_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE product_id_seq OWNER TO postgres;

--
-- TOC entry 2848 (class 0 OID 0)
-- Dependencies: 229
-- Name: product_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE product_id_seq OWNED BY product.id;


--
-- TOC entry 230 (class 1259 OID 18266)
-- Name: proposal; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE proposal (
    contractor_id integer NOT NULL,
    date_send timestamp without time zone
)
INHERITS (document);


ALTER TABLE proposal OWNER TO postgres;

--
-- TOC entry 2849 (class 0 OID 0)
-- Dependencies: 230
-- Name: TABLE proposal; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE proposal IS 'Заявки';


--
-- TOC entry 231 (class 1259 OID 18272)
-- Name: specification; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE specification (
    id integer NOT NULL,
    name character varying(50) NOT NULL,
    product_id integer NOT NULL,
    date_approval timestamp without time zone DEFAULT now(),
    comment_text text,
    cost money DEFAULT 0 NOT NULL,
    profit money DEFAULT 0 NOT NULL,
    price money DEFAULT 0 NOT NULL,
    profit_percent numeric(6,1) DEFAULT 0 NOT NULL,
    calc_price_method calculation_method DEFAULT 'profit'::calculation_method NOT NULL,
    tax_value added_tax_value DEFAULT 0 NOT NULL,
    tax_summa money DEFAULT 0 NOT NULL,
    summa money DEFAULT 0 NOT NULL,
    is_default boolean DEFAULT false NOT NULL
);


ALTER TABLE specification OWNER TO postgres;

--
-- TOC entry 2850 (class 0 OID 0)
-- Dependencies: 231
-- Name: TABLE specification; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE specification IS 'Спецификации изделий';


--
-- TOC entry 2851 (class 0 OID 0)
-- Dependencies: 231
-- Name: COLUMN specification.cost; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN specification.cost IS 'Себестоимость';


--
-- TOC entry 2852 (class 0 OID 0)
-- Dependencies: 231
-- Name: COLUMN specification.profit; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN specification.profit IS 'Прибыль';


--
-- TOC entry 2853 (class 0 OID 0)
-- Dependencies: 231
-- Name: COLUMN specification.price; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN specification.price IS 'Цена продукта без НДС';


--
-- TOC entry 2854 (class 0 OID 0)
-- Dependencies: 231
-- Name: COLUMN specification.profit_percent; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN specification.profit_percent IS 'Процент прибыли';


--
-- TOC entry 2855 (class 0 OID 0)
-- Dependencies: 231
-- Name: COLUMN specification.tax_value; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN specification.tax_value IS 'Налог на добавленную стоимость';


--
-- TOC entry 2856 (class 0 OID 0)
-- Dependencies: 231
-- Name: COLUMN specification.tax_summa; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN specification.tax_summa IS 'Сумма НДС';


--
-- TOC entry 232 (class 1259 OID 18288)
-- Name: specification_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE specification_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE specification_id_seq OWNER TO postgres;

--
-- TOC entry 2857 (class 0 OID 0)
-- Dependencies: 232
-- Name: specification_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE specification_id_seq OWNED BY specification.id;


--
-- TOC entry 233 (class 1259 OID 18290)
-- Name: supplier; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE supplier (
    id integer NOT NULL,
    contractor_id integer NOT NULL,
    material_id integer NOT NULL,
    price money DEFAULT 0
);


ALTER TABLE supplier OWNER TO postgres;

--
-- TOC entry 2858 (class 0 OID 0)
-- Dependencies: 233
-- Name: TABLE supplier; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE supplier IS 'Поставщики';


--
-- TOC entry 234 (class 1259 OID 18294)
-- Name: supplier_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE supplier_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE supplier_id_seq OWNER TO postgres;

--
-- TOC entry 2859 (class 0 OID 0)
-- Dependencies: 234
-- Name: supplier_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE supplier_id_seq OWNED BY supplier.id;


--
-- TOC entry 235 (class 1259 OID 18296)
-- Name: table_property; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE table_property (
    id integer NOT NULL,
    name character varying(25) NOT NULL,
    title character varying(50),
    has_group boolean DEFAULT false NOT NULL,
    has_child boolean DEFAULT false NOT NULL,
    show_all_root boolean DEFAULT false NOT NULL,
    refresh_current boolean DEFAULT false NOT NULL,
    refresh_master boolean DEFAULT false NOT NULL,
    refresh_before boolean DEFAULT false NOT NULL
);


ALTER TABLE table_property OWNER TO postgres;

--
-- TOC entry 236 (class 1259 OID 18305)
-- Name: table_property_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE table_property_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE table_property_id_seq OWNER TO postgres;

--
-- TOC entry 2860 (class 0 OID 0)
-- Dependencies: 236
-- Name: table_property_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE table_property_id_seq OWNED BY table_property.id;


--
-- TOC entry 237 (class 1259 OID 18307)
-- Name: tax; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE tax (
    id integer NOT NULL,
    name character varying(100) NOT NULL,
    tax_value numeric(6,2) DEFAULT 0 NOT NULL
);


ALTER TABLE tax OWNER TO postgres;

--
-- TOC entry 2861 (class 0 OID 0)
-- Dependencies: 237
-- Name: TABLE tax; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON TABLE tax IS 'Налоги, отчисления';


--
-- TOC entry 238 (class 1259 OID 18311)
-- Name: tax_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE tax_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE tax_id_seq OWNER TO postgres;

--
-- TOC entry 2862 (class 0 OID 0)
-- Dependencies: 238
-- Name: tax_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE tax_id_seq OWNED BY tax.id;


--
-- TOC entry 2227 (class 2604 OID 18313)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY article ALTER COLUMN id SET DEFAULT nextval('article_id_seq'::regclass);


--
-- TOC entry 2229 (class 2604 OID 18314)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY bank ALTER COLUMN id SET DEFAULT nextval('bank_id_seq'::regclass);


--
-- TOC entry 2239 (class 2604 OID 18315)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY column_item ALTER COLUMN id SET DEFAULT nextval('column_item_id_seq'::regclass);


--
-- TOC entry 2243 (class 2604 OID 18316)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY contractor ALTER COLUMN id SET DEFAULT nextval('contractor_id_seq'::regclass);


--
-- TOC entry 2248 (class 2604 OID 18317)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY document ALTER COLUMN id SET DEFAULT nextval('document_common_id_seq'::regclass);


--
-- TOC entry 2249 (class 2604 OID 18318)
-- Name: accept; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY document ALTER COLUMN accept SET DEFAULT true;


--
-- TOC entry 2250 (class 2604 OID 18319)
-- Name: date_created; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY document ALTER COLUMN date_created SET DEFAULT now();


--
-- TOC entry 2246 (class 2604 OID 18320)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY document_common ALTER COLUMN id SET DEFAULT nextval('document_common_id_seq'::regclass);


--
-- TOC entry 2252 (class 2604 OID 18321)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY employee ALTER COLUMN id SET DEFAULT nextval('employee_id_seq'::regclass);


--
-- TOC entry 2253 (class 2604 OID 18322)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY group_item ALTER COLUMN id SET DEFAULT nextval('group_item_id_seq'::regclass);


--
-- TOC entry 2254 (class 2604 OID 18323)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY image ALTER COLUMN id SET DEFAULT nextval('image_id_seq'::regclass);


--
-- TOC entry 2255 (class 2604 OID 18324)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice ALTER COLUMN id SET DEFAULT nextval('document_common_id_seq'::regclass);


--
-- TOC entry 2256 (class 2604 OID 18325)
-- Name: accept; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice ALTER COLUMN accept SET DEFAULT true;


--
-- TOC entry 2257 (class 2604 OID 18326)
-- Name: date_created; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice ALTER COLUMN date_created SET DEFAULT now();


--
-- TOC entry 2258 (class 2604 OID 18327)
-- Name: summa; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice ALTER COLUMN summa SET DEFAULT 0;


--
-- TOC entry 2259 (class 2604 OID 18328)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_contractor ALTER COLUMN id SET DEFAULT nextval('document_common_id_seq'::regclass);


--
-- TOC entry 2260 (class 2604 OID 18329)
-- Name: accept; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_contractor ALTER COLUMN accept SET DEFAULT true;


--
-- TOC entry 2261 (class 2604 OID 18330)
-- Name: date_created; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_contractor ALTER COLUMN date_created SET DEFAULT now();


--
-- TOC entry 2262 (class 2604 OID 18331)
-- Name: summa; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_contractor ALTER COLUMN summa SET DEFAULT 0;


--
-- TOC entry 2263 (class 2604 OID 18332)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_expense ALTER COLUMN id SET DEFAULT nextval('document_common_id_seq'::regclass);


--
-- TOC entry 2264 (class 2604 OID 18333)
-- Name: accept; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_expense ALTER COLUMN accept SET DEFAULT true;


--
-- TOC entry 2265 (class 2604 OID 18334)
-- Name: date_created; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_expense ALTER COLUMN date_created SET DEFAULT now();


--
-- TOC entry 2266 (class 2604 OID 18335)
-- Name: summa; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_expense ALTER COLUMN summa SET DEFAULT 0;


--
-- TOC entry 2267 (class 2604 OID 18839)
-- Name: direction; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_expense ALTER COLUMN direction SET DEFAULT '-1'::integer;


--
-- TOC entry 2268 (class 2604 OID 18336)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_income ALTER COLUMN id SET DEFAULT nextval('document_common_id_seq'::regclass);


--
-- TOC entry 2269 (class 2604 OID 18337)
-- Name: accept; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_income ALTER COLUMN accept SET DEFAULT true;


--
-- TOC entry 2270 (class 2604 OID 18338)
-- Name: date_created; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_income ALTER COLUMN date_created SET DEFAULT now();


--
-- TOC entry 2272 (class 2604 OID 18340)
-- Name: summa; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_income ALTER COLUMN summa SET DEFAULT 0;


--
-- TOC entry 2271 (class 2604 OID 18339)
-- Name: direction; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_income ALTER COLUMN direction SET DEFAULT 1;


--
-- TOC entry 2273 (class 2604 OID 18341)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_write_off ALTER COLUMN id SET DEFAULT nextval('document_common_id_seq'::regclass);


--
-- TOC entry 2274 (class 2604 OID 18342)
-- Name: accept; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_write_off ALTER COLUMN accept SET DEFAULT true;


--
-- TOC entry 2275 (class 2604 OID 18343)
-- Name: date_created; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_write_off ALTER COLUMN date_created SET DEFAULT now();


--
-- TOC entry 2277 (class 2604 OID 18345)
-- Name: summa; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_write_off ALTER COLUMN summa SET DEFAULT 0;


--
-- TOC entry 2276 (class 2604 OID 18344)
-- Name: direction; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_write_off ALTER COLUMN direction SET DEFAULT '-1'::integer;


--
-- TOC entry 2280 (class 2604 OID 18346)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item ALTER COLUMN id SET DEFAULT nextval('item_id_seq'::regclass);


--
-- TOC entry 2281 (class 2604 OID 18347)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_document ALTER COLUMN id SET DEFAULT nextval('item_id_seq'::regclass);


--
-- TOC entry 2282 (class 2604 OID 18348)
-- Name: price; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_document ALTER COLUMN price SET DEFAULT 0;


--
-- TOC entry 2283 (class 2604 OID 18349)
-- Name: summa; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_document ALTER COLUMN summa SET DEFAULT 0;


--
-- TOC entry 2353 (class 2604 OID 18817)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_invoice_expense ALTER COLUMN id SET DEFAULT nextval('item_id_seq'::regclass);


--
-- TOC entry 2354 (class 2604 OID 18818)
-- Name: price; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_invoice_expense ALTER COLUMN price SET DEFAULT 0;


--
-- TOC entry 2355 (class 2604 OID 18819)
-- Name: summa; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_invoice_expense ALTER COLUMN summa SET DEFAULT 0;


--
-- TOC entry 2350 (class 2604 OID 18780)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_invoice_income ALTER COLUMN id SET DEFAULT nextval('item_id_seq'::regclass);


--
-- TOC entry 2351 (class 2604 OID 18781)
-- Name: price; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_invoice_income ALTER COLUMN price SET DEFAULT 0;


--
-- TOC entry 2352 (class 2604 OID 18782)
-- Name: summa; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_invoice_income ALTER COLUMN summa SET DEFAULT 0;


--
-- TOC entry 2287 (class 2604 OID 18350)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_material ALTER COLUMN id SET DEFAULT nextval('item_id_seq'::regclass);


--
-- TOC entry 2288 (class 2604 OID 18351)
-- Name: price; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_material ALTER COLUMN price SET DEFAULT 0;


--
-- TOC entry 2289 (class 2604 OID 18352)
-- Name: summa; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_material ALTER COLUMN summa SET DEFAULT 0;


--
-- TOC entry 2290 (class 2604 OID 18353)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_operation ALTER COLUMN id SET DEFAULT nextval('item_id_seq'::regclass);


--
-- TOC entry 2291 (class 2604 OID 18354)
-- Name: price; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_operation ALTER COLUMN price SET DEFAULT 0;


--
-- TOC entry 2292 (class 2604 OID 18355)
-- Name: summa; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_operation ALTER COLUMN summa SET DEFAULT 0;


--
-- TOC entry 2293 (class 2604 OID 18356)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_product ALTER COLUMN id SET DEFAULT nextval('item_id_seq'::regclass);


--
-- TOC entry 2294 (class 2604 OID 18357)
-- Name: price; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_product ALTER COLUMN price SET DEFAULT 0;


--
-- TOC entry 2295 (class 2604 OID 18358)
-- Name: summa; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_product ALTER COLUMN summa SET DEFAULT 0;


--
-- TOC entry 2297 (class 2604 OID 18359)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_proposal ALTER COLUMN id SET DEFAULT nextval('item_id_seq'::regclass);


--
-- TOC entry 2298 (class 2604 OID 18360)
-- Name: price; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_proposal ALTER COLUMN price SET DEFAULT 0;


--
-- TOC entry 2299 (class 2604 OID 18361)
-- Name: summa; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_proposal ALTER COLUMN summa SET DEFAULT 0;


--
-- TOC entry 2284 (class 2604 OID 18362)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_specification ALTER COLUMN id SET DEFAULT nextval('item_id_seq'::regclass);


--
-- TOC entry 2285 (class 2604 OID 18363)
-- Name: price; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_specification ALTER COLUMN price SET DEFAULT 0;


--
-- TOC entry 2286 (class 2604 OID 18364)
-- Name: summa; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_specification ALTER COLUMN summa SET DEFAULT 0;


--
-- TOC entry 2300 (class 2604 OID 18365)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_tax ALTER COLUMN id SET DEFAULT nextval('item_id_seq'::regclass);


--
-- TOC entry 2301 (class 2604 OID 18366)
-- Name: price; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_tax ALTER COLUMN price SET DEFAULT 0;


--
-- TOC entry 2302 (class 2604 OID 18367)
-- Name: summa; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_tax ALTER COLUMN summa SET DEFAULT 0;


--
-- TOC entry 2309 (class 2604 OID 18368)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY material ALTER COLUMN id SET DEFAULT nextval('material_id_seq'::regclass);


--
-- TOC entry 2310 (class 2604 OID 18369)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY material_detail ALTER COLUMN id SET DEFAULT nextval('material_detail_id_seq'::regclass);


--
-- TOC entry 2312 (class 2604 OID 18370)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY measurement ALTER COLUMN id SET DEFAULT nextval('measurement_id_seq'::regclass);


--
-- TOC entry 2315 (class 2604 OID 18371)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY numerator ALTER COLUMN id SET DEFAULT nextval('numerator_id_seq'::regclass);


--
-- TOC entry 2316 (class 2604 OID 18372)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY okopf ALTER COLUMN id SET DEFAULT nextval('okopf_id_seq'::regclass);


--
-- TOC entry 2317 (class 2604 OID 18373)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY okpdtr ALTER COLUMN id SET DEFAULT nextval('okpdtr_id_seq'::regclass);


--
-- TOC entry 2321 (class 2604 OID 18374)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY operation ALTER COLUMN id SET DEFAULT nextval('operation_id_seq'::regclass);


--
-- TOC entry 2322 (class 2604 OID 18375)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY person ALTER COLUMN id SET DEFAULT nextval('person_id_seq'::regclass);


--
-- TOC entry 2323 (class 2604 OID 18376)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY product ALTER COLUMN id SET DEFAULT nextval('product_id_seq'::regclass);


--
-- TOC entry 2325 (class 2604 OID 18377)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY proposal ALTER COLUMN id SET DEFAULT nextval('document_common_id_seq'::regclass);


--
-- TOC entry 2326 (class 2604 OID 18378)
-- Name: accept; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY proposal ALTER COLUMN accept SET DEFAULT true;


--
-- TOC entry 2324 (class 2604 OID 18379)
-- Name: date_created; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY proposal ALTER COLUMN date_created SET DEFAULT now();


--
-- TOC entry 2327 (class 2604 OID 18380)
-- Name: summa; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY proposal ALTER COLUMN summa SET DEFAULT 0;


--
-- TOC entry 2338 (class 2604 OID 18381)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY specification ALTER COLUMN id SET DEFAULT nextval('specification_id_seq'::regclass);


--
-- TOC entry 2340 (class 2604 OID 18382)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY supplier ALTER COLUMN id SET DEFAULT nextval('supplier_id_seq'::regclass);


--
-- TOC entry 2347 (class 2604 OID 18383)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY table_property ALTER COLUMN id SET DEFAULT nextval('table_property_id_seq'::regclass);


--
-- TOC entry 2349 (class 2604 OID 18384)
-- Name: id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY tax ALTER COLUMN id SET DEFAULT nextval('tax_id_seq'::regclass);


--
-- TOC entry 2726 (class 0 OID 18066)
-- Dependencies: 181
-- Data for Name: article; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO article (id, name, code, content, calculation, printable, items_printable, bolded, print_zero_value) VALUES (9, 'НДС начисленный', 900, 'none', 'tax', true, false, false, false);
INSERT INTO article (id, name, code, content, calculation, printable, items_printable, bolded, print_zero_value) VALUES (1, 'Сырье и основные материалы', 100, 'material', 'content', true, true, false, false);
INSERT INTO article (id, name, code, content, calculation, printable, items_printable, bolded, print_zero_value) VALUES (2, 'Покупные полуфабрикаты', 200, 'material', 'content', false, false, false, false);
INSERT INTO article (id, name, code, content, calculation, printable, items_printable, bolded, print_zero_value) VALUES (8, 'Свободная отпускная цена', 800, 'none', 'price', true, false, true, false);
INSERT INTO article (id, name, code, content, calculation, printable, items_printable, bolded, print_zero_value) VALUES (10, 'Цена с НДС', 999, 'none', 'summa', true, false, true, false);
INSERT INTO article (id, name, code, content, calculation, printable, items_printable, bolded, print_zero_value) VALUES (7, 'Прибыль', 750, 'none', 'profit', true, false, false, false);
INSERT INTO article (id, name, code, content, calculation, printable, items_printable, bolded, print_zero_value) VALUES (6, 'Производственая себестоимость', 700, 'none', 'cost', true, false, true, false);
INSERT INTO article (id, name, code, content, calculation, printable, items_printable, bolded, print_zero_value) VALUES (5, 'Накладные расходы', 600, 'tax', 'content', true, true, false, false);
INSERT INTO article (id, name, code, content, calculation, printable, items_printable, bolded, print_zero_value) VALUES (4, 'Налоги и сборы', 500, 'tax', 'content', true, true, false, false);
INSERT INTO article (id, name, code, content, calculation, printable, items_printable, bolded, print_zero_value) VALUES (3, 'Заработная плата', 400, 'operation', 'content', true, true, false, false);
INSERT INTO article (id, name, code, content, calculation, printable, items_printable, bolded, print_zero_value) VALUES (17, 'Материалы собственного производства', 300, 'product', 'content', true, true, false, false);


--
-- TOC entry 2863 (class 0 OID 0)
-- Dependencies: 182
-- Name: article_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('article_id_seq', 17, true);


--
-- TOC entry 2728 (class 0 OID 18076)
-- Dependencies: 183
-- Data for Name: bank; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO bank (id, name, bik, account) VALUES (2, 'АО "ТАТСОЦБАНК"', 49205703, 30101810500000000703);
INSERT INTO bank (id, name, bik, account) VALUES (3, 'Чувашское отделение №8613 ПАО Сбербанк', 49706609, 30101810300000000609);
INSERT INTO bank (id, name, bik, account) VALUES (1, 'Ульяновское отделение №8588 ПАО Сбербанк', 47308602, 30101810000000000602);


--
-- TOC entry 2864 (class 0 OID 0)
-- Dependencies: 184
-- Name: bank_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('bank_id_seq', 3, true);


--
-- TOC entry 2730 (class 0 OID 18081)
-- Dependencies: 185
-- Data for Name: column_item; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (1, 'Code', 'Код', 100, 'not_set', 100, 'not_set', '000', false, 1, 1, true, NULL, false, 1);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (2, 'Name', 'Наименование', 100, 'fill', 100, 'not_set', NULL, false, 2, 1, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (3, 'Abbreviation', 'Сокр. наименование', 120, 'not_set', 100, 'not_set', NULL, false, 3, 1, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (4, 'Name', 'Наименование', 100, 'fill', 100, 'not_set', NULL, false, 1, 2, true, NULL, false, 1);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (5, 'TaxValue', 'Ставка', 120, 'not_set', 100, 'middle_right', '0.00\%', false, 2, 2, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (6, 'Name', 'Наименование', 100, 'fill', 100, 'not_set', NULL, false, 1, 3, true, NULL, false, 1);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (7, 'Bik', 'БИК', 90, 'not_set', 100, 'not_set', NULL, false, 2, 3, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (8, 'Account', 'Корр. счёт', 150, 'not_set', 100, 'not_set', NULL, false, 3, 3, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (9, 'Code', 'Код', 80, 'not_set', 100, 'not_set', NULL, false, 1, 4, true, NULL, false, 1);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (10, 'Name', 'Наименование', 100, 'fill', 100, 'not_set', NULL, false, 2, 4, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (11, 'Code', 'Код', 100, 'not_set', 100, 'not_set', NULL, false, 1, 5, true, NULL, false, 1);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (12, 'AdvancedViewName', 'Наименование', 100, 'fill', 100, 'not_set', NULL, false, 2, 5, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (13, 'Name', 'Наименование', 100, 'fill', 100, 'not_set', NULL, false, 1, 6, true, NULL, false, 1);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (14, 'Measurement', 'Ед. изм.', 100, 'not_set', 100, 'not_set', NULL, false, 2, 6, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (15, 'Price', 'Цена', 100, 'not_set', 100, 'middle_right', '0.00', false, 3, 6, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (16, 'TaxValue', 'НДС', 100, 'not_set', 100, 'middle_right', '0\%', false, 4, 6, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (17, 'Name', 'Наименование', 100, 'fill', 100, 'not_set', NULL, false, 1, 7, true, NULL, false, 1);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (18, 'TimeRate', 'Норма времени', 120, 'not_set', 100, 'middle_right', NULL, false, 2, 7, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (19, 'Price', 'Расценка', 120, 'not_set', 100, 'middle_right', '0.000', false, 3, 7, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (56, 'Name', 'Наименование', 100, 'fill', 100, 'not_set', NULL, false, 2, 8, true, NULL, false, 2);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (57, 'Cost', 'Себестоимость', 100, 'not_set', 100, 'middle_right', '0.00', false, 3, 8, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (58, 'Profit', 'Прибыль', 100, 'not_set', 100, 'middle_right', '0.00', false, 4, 8, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (63, 'Name', 'Наименование', 100, 'fill', 100, 'not_set', NULL, false, 1, 9, true, NULL, false, 1);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (64, 'Price', 'Цена', 100, 'not_set', 100, 'middle_right', '0.00', false, 2, 9, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (65, 'TaxValue', 'НДС', 100, 'not_set', 100, 'middle_right', '0\%', false, 3, 9, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (66, 'TaxSumma', 'Сумма НДС', 100, 'not_set', 100, 'middle_right', '0.00', false, 4, 9, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (67, 'Summa', 'Сумма', 100, 'not_set', 100, 'middle_right', '0.00', false, 5, 9, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (68, 'ArticleCode', 'Артикль', 140, 'not_set', 100, 'not_set', NULL, false, 6, 9, false, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (69, 'FullName', 'Полное наименование', 100, 'fill', 100, 'not_set', NULL, false, 7, 9, false, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (75, 'Material', 'Материал', 100, 'fill', 100, 'not_set', NULL, false, 1, 11, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (76, 'Price', 'Цена', 100, 'not_set', 100, 'not_set', '0.00', false, 2, 11, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (77, 'Contractor', 'Поставщик', 120, 'not_set', 100, 'not_set', NULL, true, 3, 11, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (74, 'Contractor', 'Место работы', 100, 'not_set', 100, 'not_set', NULL, true, 4, 10, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (71, 'Person', 'Имя', 100, 'fill', 100, 'not_set', NULL, false, 1, 10, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (60, 'Price', 'Цена', 100, 'not_set', 100, 'middle_right', '0.00', false, 5, 8, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (61, 'Comment', 'Комментарий', 100, 'fill', 100, 'not_set', NULL, false, 6, 8, false, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (62, 'ProfitPercent', 'Процент прибыли', 100, 'not_set', 100, 'middle_right', '0.0\%', false, 7, 8, false, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (78, 'Name', 'Наименование', 100, 'fill', 100, 'not_set', NULL, false, 1, 12, true, NULL, false, 1);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (79, 'INN', 'ИНН', 120, 'not_set', 100, 'not_set', NULL, false, 2, 12, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (80, 'KPP', 'КПП', 120, 'not_set', 100, 'not_set', NULL, false, 3, 12, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (82, 'Price', 'Цена', 60, 'not_set', 100, 'middle_right', '0.00', false, 2, 14, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (84, 'Summa', 'Сумма', 80, 'not_set', 100, 'middle_right', '0.00', false, 4, 14, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (86, 'Price', 'Цена', 60, 'not_set', 100, 'middle_right', '0.00', false, 2, 15, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (88, 'Summa', 'Сумма', 80, 'not_set', 100, 'middle_right', '0.00', false, 4, 15, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (89, 'Tax', 'Наименование', 90, 'fill', 100, 'not_set', NULL, false, 1, 17, true, NULL, true, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (91, 'Summa', 'Сумма', 60, 'not_set', 100, 'middle_right', '0.00', false, 4, 17, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (92, 'Source', 'От...', 140, 'not_set', 100, 'not_set', NULL, false, 3, 17, true, 13, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (96, 'Phone', 'Телефон', 120, 'not_set', 100, 'not_set', NULL, false, 4, 19, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (100, 'Contractor', 'Контрагент', 100, 'fill', 100, 'not_set', NULL, false, 3, 20, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (103, 'Contractor', 'Контрагент', 100, 'fill', 100, 'not_set', NULL, false, 3, 21, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (106, 'Contractor', 'Контрагент', 100, 'fill', 100, 'not_set', NULL, false, 3, 22, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (107, 'Material', 'Материал', 100, 'fill', 100, 'not_set', NULL, false, 1, 23, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (93, 'Surname', 'Фамилия', 100, 'fill', 35, 'not_set', NULL, false, 1, 19, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (94, 'FirstName', 'Имя', 100, 'fill', 25, 'not_set', NULL, false, 2, 19, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (95, 'MiddleName', 'Отчество', 100, 'fill', 50, 'not_set', NULL, false, 3, 19, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (97, 'Name', 'Отоброжаемое имя', 100, 'not_set', 100, 'not_set', NULL, false, 5, 19, false, NULL, false, 1);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (55, 'DateApproval', 'Дата', 100, 'not_set', 100, 'not_set', NULL, false, 1, 8, true, NULL, false, 1);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (83, 'CountItems', 'Количество', 80, 'not_set', 100, 'middle_right', '0.000', false, 3, 14, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (87, 'CountItems', 'Количество', 80, 'not_set', 100, 'middle_right', '0.000', false, 3, 15, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (90, 'CountItems', 'Процент', 60, 'not_set', 100, 'middle_right', '0.00\%', false, 2, 17, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (81, 'MaterialDetail', 'Наименование', 100, 'fill', 100, 'not_set', NULL, false, 1, 14, true, NULL, true, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (104, 'DateCreated', 'Дата', 100, 'not_set', 100, 'not_set', NULL, false, 1, 22, true, NULL, false, 1);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (105, 'ReferenceNumber', 'Номер', 50, 'not_set', 100, 'not_set', NULL, false, 2, 22, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (85, 'Operation', 'Наименование', 100, 'fill', 100, 'not_set', NULL, false, 1, 15, true, NULL, true, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (112, 'Product', 'Наименование', 100, 'fill', 100, 'not_set', NULL, false, 1, 25, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (113, 'Price', 'Цена', 60, 'not_set', 100, 'middle_right', '0.00', false, 2, 25, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (72, 'Post', 'Должность', 140, 'not_set', 100, 'not_set', NULL, false, 2, 10, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (73, 'Phone', 'Телефон', 120, 'not_set', 100, 'not_set', NULL, false, 3, 10, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (110, 'Summa', 'Сумма', 80, 'not_set', 100, 'middle_right', '0.00', false, 4, 23, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (109, 'Price', 'Цена', 60, 'not_set', 100, 'middle_right', '0.00', false, 3, 23, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (108, 'CountItems', 'Количество', 80, 'not_set', 100, 'middle_right', '0.000', false, 2, 23, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (111, 'Summa', 'Сумма', 100, 'not_set', 100, 'middle_right', '0.00', false, 4, 22, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (114, 'CountItems', 'Количество', 80, 'not_set', 100, 'middle_right', '0.000', false, 3, 25, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (98, 'DateCreated', 'Дата', 100, 'not_set', 100, 'not_set', NULL, false, 1, 20, true, NULL, false, 1);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (99, 'ReferenceNumber', 'Номер', 50, 'not_set', 100, 'not_set', NULL, false, 2, 20, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (102, 'ReferenceNumber', 'Номер', 50, 'not_set', 100, 'not_set', NULL, false, 2, 21, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (115, 'Summa', 'Сумма', 80, 'not_set', 100, 'middle_right', '0.00', false, 4, 25, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (116, 'SendStatus', 'Статус', 120, 'not_set', 100, 'not_set', NULL, false, 5, 22, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (118, 'Material', 'Материал', 100, 'fill', 100, 'not_set', NULL, false, 1, 26, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (119, 'CountItems', 'Количество', 80, 'not_set', 100, 'middle_right', '0.000', false, 2, 26, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (120, 'Price', 'Цена', 60, 'not_set', 100, 'middle_right', '0.00', false, 3, 26, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (121, 'Summa', 'Сумма', 80, 'not_set', 100, 'middle_right', '0.00', false, 4, 26, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (101, 'DateCreated', 'Дата', 100, 'not_set', 100, 'not_set', NULL, false, 1, 21, true, NULL, false, 1);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (122, 'Material', 'Материал', 100, 'fill', 100, 'not_set', NULL, false, 1, 27, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (123, 'CountItems', 'Количество', 80, 'not_set', 100, 'middle_right', '0.000', false, 2, 27, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (124, 'Price', 'Цена', 60, 'not_set', 100, 'middle_right', '0.00', false, 3, 27, true, NULL, false, 0);
INSERT INTO column_item (id, name, header, width, mode, fill_weight, alignment, format, hide_on_group, index, table_id, visible, source_id, frozen, sorted) VALUES (125, 'Summa', 'Сумма', 80, 'not_set', 100, 'middle_right', '0.00', false, 4, 27, true, NULL, false, 0);


--
-- TOC entry 2865 (class 0 OID 0)
-- Dependencies: 186
-- Name: column_item_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('column_item_id_seq', 125, true);


--
-- TOC entry 2732 (class 0 OID 18095)
-- Dependencies: 187
-- Data for Name: contractor; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO contractor (id, name, short_name, full_name, okopf_id, inn, kpp, ogrn, address, phone, fax, email, web, okpo, account, bank_id, our_firm, group_id) VALUES (12, 'Копир', 'АО "ЗАВОД "КОПИР"', 'АКЦИОНЕРНОЕ ОБЩЕСТВО "ЗАВОД "КОПИР"', 1, 1217000287, 121701001, 1021202049637, '425350, Марий Эл Респ, Козьмодемьянск г, Гагарина ул, дом № 10', '(83632) 7-12-39', '(83632) 7-12-39', 'mail@zavod-kopir.ru', 'www.zavod-kopir.ru', NULL, 40702810000000000356, 2, false, 22);
INSERT INTO contractor (id, name, short_name, full_name, okopf_id, inn, kpp, ogrn, address, phone, fax, email, web, okpo, account, bank_id, our_firm, group_id) VALUES (13, 'Марпосадкабель', 'АО "Марпосадкабель"', 'Акционерное общество "Марпосадкабель"', 1, 2111006918, 211101001, NULL, NULL, '8 (499) 346-21-24', NULL, 'info@mpkabel.ru', 'http://www.mpkabel.ru', NULL, 40702810775150100184, 3, false, 22);
INSERT INTO contractor (id, name, short_name, full_name, okopf_id, inn, kpp, ogrn, address, phone, fax, email, web, okpo, account, bank_id, our_firm, group_id) VALUES (11, 'Автоком', 'ООО "Автоком"', 'Общество с ограниченной ответственностью "Автоком"', 2, 7329008334, 732901001, 1127329002492, '433513, Россия, Ульяновская область, город Димитровград, проспект Автостроителей, дом 93', '(84235) 4-58-38', NULL, 'office@autokom.company', NULL, NULL, 40702810669110010415, 1, true, 22);
INSERT INTO contractor (id, name, short_name, full_name, okopf_id, inn, kpp, ogrn, address, phone, fax, email, web, okpo, account, bank_id, our_firm, group_id) VALUES (5, 'ДЗАК', 'ООО "ДЗАК"', 'Общество с ограниченной ответственностью "Димитровградский завод автомобильных компонентов"', 2, 7302041415, 730201001, 1097302000179, '433513, Россия, Ульяновская обл., г. Димитровград, пр. Автостроителей 91', '+7 (84235) 4-58-38', '+7 (84235) 4-58-38', 'office@dzak.ru', NULL, NULL, 40702810669110002627, 1, true, 22);


--
-- TOC entry 2866 (class 0 OID 0)
-- Dependencies: 188
-- Name: contractor_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('contractor_id_seq', 17, true);


--
-- TOC entry 2735 (class 0 OID 18112)
-- Dependencies: 190
-- Data for Name: document; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2734 (class 0 OID 18107)
-- Dependencies: 189
-- Data for Name: document_common; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2867 (class 0 OID 0)
-- Dependencies: 191
-- Name: document_common_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('document_common_id_seq', 22, true);


--
-- TOC entry 2737 (class 0 OID 18120)
-- Dependencies: 192
-- Data for Name: employee; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO employee (id, contractor_id, person_id, post_id, phone, email, status, fax) VALUES (4, 5, 2, 2, NULL, 'office@dzak.ru', 'general', NULL);
INSERT INTO employee (id, contractor_id, person_id, post_id, phone, email, status, fax) VALUES (5, 11, 21, 2, NULL, 'office@autokom.company', 'general', NULL);
INSERT INTO employee (id, contractor_id, person_id, post_id, phone, email, status, fax) VALUES (6, 13, 22, NULL, '(800) 555-21-24 (доб. 2006) ', 'mgm@mpkabel.ru', 'employee', NULL);
INSERT INTO employee (id, contractor_id, person_id, post_id, phone, email, status, fax) VALUES (7, 12, 36, NULL, '(83632) 7-73-70', 'os_rimma@zavod-kopir.ru', 'undefined', NULL);


--
-- TOC entry 2868 (class 0 OID 0)
-- Dependencies: 193
-- Name: employee_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('employee_id_seq', 7, true);


--
-- TOC entry 2739 (class 0 OID 18126)
-- Dependencies: 194
-- Data for Name: group_item; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO group_item (id, name, table_id, parent_id) VALUES (1, 'Резка провода', 7, NULL);
INSERT INTO group_item (id, name, table_id, parent_id) VALUES (2, 'Жгут стеклоподъемника', 7, NULL);
INSERT INTO group_item (id, name, table_id, parent_id) VALUES (22, 'Юр. лица', 12, NULL);
INSERT INTO group_item (id, name, table_id, parent_id) VALUES (23, 'Провод', 6, NULL);
INSERT INTO group_item (id, name, table_id, parent_id) VALUES (24, 'Колодки', 6, NULL);
INSERT INTO group_item (id, name, table_id, parent_id) VALUES (25, 'Наконечники', 6, NULL);
INSERT INTO group_item (id, name, table_id, parent_id) VALUES (27, 'Test', 6, NULL);
INSERT INTO group_item (id, name, table_id, parent_id) VALUES (28, 'Test2', 6, 27);


--
-- TOC entry 2869 (class 0 OID 0)
-- Dependencies: 195
-- Name: group_item_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('group_item_id_seq', 28, true);


--
-- TOC entry 2741 (class 0 OID 18131)
-- Dependencies: 196
-- Data for Name: image; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO image (id, source, name) VALUES (13, 'C:\Users\Сергей\Pictures\Ferrary.jpg', 'Ferrary.jpg');
INSERT INTO image (id, source, name) VALUES (15, 'C:\Users\Сергей\Pictures\image1.jpg', 'image1.jpg');
INSERT INTO image (id, source, name) VALUES (16, 'C:\Users\Сергей\Pictures\Новая папка\image1.jpg', 'image1_00.jpg');
INSERT INTO image (id, source, name) VALUES (17, NULL, '2008.05.30 19.55.08.png');
INSERT INTO image (id, source, name) VALUES (18, NULL, 'Ferrary_00.jpg');


--
-- TOC entry 2870 (class 0 OID 0)
-- Dependencies: 197
-- Name: image_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('image_id_seq', 18, true);


--
-- TOC entry 2743 (class 0 OID 18136)
-- Dependencies: 198
-- Data for Name: invoice; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2744 (class 0 OID 18142)
-- Dependencies: 199
-- Data for Name: invoice_contractor; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2745 (class 0 OID 18148)
-- Dependencies: 200
-- Data for Name: invoice_expense; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO invoice_expense (id, accept, date_created, reference_number, summa, direction, contractor_id, organization_id) VALUES (20, true, '2016-05-12 08:57:00', 1, '1 645,00р.', -1, 5, 11);


--
-- TOC entry 2746 (class 0 OID 18154)
-- Dependencies: 201
-- Data for Name: invoice_income; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO invoice_income (id, accept, date_created, reference_number, summa, direction, contractor_id, organization_id) VALUES (17, true, '2016-05-11 15:09:45', 3, '5 640,00р.', 1, 12, 11);
INSERT INTO invoice_income (id, accept, date_created, reference_number, summa, direction, contractor_id, organization_id) VALUES (18, true, '2016-05-11 15:24:56', 4, '2 840,00р.', 1, 12, 11);


--
-- TOC entry 2747 (class 0 OID 18160)
-- Dependencies: 202
-- Data for Name: invoice_write_off; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2748 (class 0 OID 18166)
-- Dependencies: 203
-- Data for Name: item; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2749 (class 0 OID 18171)
-- Dependencies: 204
-- Data for Name: item_document; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2871 (class 0 OID 0)
-- Dependencies: 205
-- Name: item_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('item_id_seq', 141, true);


--
-- TOC entry 2785 (class 0 OID 18814)
-- Dependencies: 240
-- Data for Name: item_invoice_expense; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO item_invoice_expense (id, element_id, price, count_items, summa, document_id) VALUES (106, 7, '0,47р.', 2000.000, '940,00р.', 20);
INSERT INTO item_invoice_expense (id, element_id, price, count_items, summa, document_id) VALUES (107, 6, '0,47р.', 1500.000, '705,00р.', 20);


--
-- TOC entry 2784 (class 0 OID 18777)
-- Dependencies: 239
-- Data for Name: item_invoice_income; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO item_invoice_income (id, element_id, price, count_items, summa, document_id) VALUES (103, 7, '0,47р.', 6000.000, '2 820,00р.', 17);
INSERT INTO item_invoice_income (id, element_id, price, count_items, summa, document_id) VALUES (104, 6, '0,47р.', 6000.000, '2 820,00р.', 17);
INSERT INTO item_invoice_income (id, element_id, price, count_items, summa, document_id) VALUES (105, 35, '0,71р.', 4000.000, '2 840,00р.', 18);


--
-- TOC entry 2752 (class 0 OID 18183)
-- Dependencies: 207
-- Data for Name: item_material; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO item_material (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (85, 8, '3,14р.', 0.220, '0,69р.', 1, 53);
INSERT INTO item_material (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (86, 35, '0,71р.', 1.000, '0,71р.', 1, 53);
INSERT INTO item_material (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (87, 45, '0,71р.', 1.000, '0,71р.', 1, 53);
INSERT INTO item_material (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (88, 37, '0,82р.', 1.000, '0,82р.', 1, 53);
INSERT INTO item_material (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (117, 38, '2,37р.', 1.000, '2,37р.', 1, 54);
INSERT INTO item_material (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (118, 6, '0,47р.', 7.000, '3,29р.', 1, 54);
INSERT INTO item_material (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (119, 7, '0,47р.', 7.000, '3,29р.', 1, 54);
INSERT INTO item_material (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (120, 37, '0,82р.', 1.000, '0,82р.', 1, 54);
INSERT INTO item_material (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (121, 35, '0,71р.', 4.000, '2,84р.', 1, 54);
INSERT INTO item_material (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (108, 41, '2,54р.', 2.700, '6,86р.', 1, 54);
INSERT INTO item_material (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (111, 42, '2,54р.', 0.500, '1,27р.', 1, 54);
INSERT INTO item_material (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (110, 43, '2,54р.', 0.500, '1,27р.', 1, 54);
INSERT INTO item_material (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (109, 44, '2,54р.', 2.700, '6,86р.', 1, 54);
INSERT INTO item_material (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (112, 8, '2,54р.', 0.900, '2,29р.', 1, 54);


--
-- TOC entry 2753 (class 0 OID 18188)
-- Dependencies: 208
-- Data for Name: item_operation; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO item_operation (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (89, 1, '0,05р.', 3.000, '0,14р.', 3, 53);
INSERT INTO item_operation (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (90, 29, '0,19р.', 3.000, '0,57р.', 3, 53);
INSERT INTO item_operation (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (91, 4, '0,04р.', 1.000, '0,04р.', 3, 53);
INSERT INTO item_operation (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (92, 6, '0,04р.', 1.000, '0,04р.', 3, 53);
INSERT INTO item_operation (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (113, 4, '0,02р.', 4.000, '0,06р.', 3, 54);
INSERT INTO item_operation (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (114, 34, '0,05р.', 4.000, '0,20р.', 3, 54);
INSERT INTO item_operation (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (115, 9, '0,02р.', 3.000, '0,07р.', 3, 54);
INSERT INTO item_operation (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (116, 6, '0,02р.', 3.000, '0,05р.', 3, 54);
INSERT INTO item_operation (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (122, 26, '2,93р.', 1.000, '2,93р.', 3, 54);
INSERT INTO item_operation (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (123, 1, '0,05р.', 5.000, '0,22р.', 3, 54);
INSERT INTO item_operation (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (124, 29, '0,19р.', 5.000, '0,94р.', 3, 54);
INSERT INTO item_operation (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (125, 30, '0,04р.', 14.000, '0,49р.', 3, 54);
INSERT INTO item_operation (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (126, 2, '0,05р.', 4.000, '0,22р.', 3, 54);
INSERT INTO item_operation (id, element_id, price, count_items, summa, article_id, specification_id) VALUES (127, 20, '0,11р.', 4.000, '0,45р.', 3, 54);


--
-- TOC entry 2754 (class 0 OID 18193)
-- Dependencies: 209
-- Data for Name: item_product; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2755 (class 0 OID 18199)
-- Dependencies: 210
-- Data for Name: item_proposal; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO item_proposal (id, element_id, price, count_items, summa, document_id) VALUES (75, 6, '0,47р.', 18000.000, '8 460,00р.', 8);
INSERT INTO item_proposal (id, element_id, price, count_items, summa, document_id) VALUES (74, 7, '0,47р.', 18000.000, '8 460,00р.', 8);
INSERT INTO item_proposal (id, element_id, price, count_items, summa, document_id) VALUES (78, 33, '0,74р.', 4000.000, '2 960,00р.', 8);
INSERT INTO item_proposal (id, element_id, price, count_items, summa, document_id) VALUES (76, 35, '0,71р.', 16000.000, '11 360,00р.', 8);
INSERT INTO item_proposal (id, element_id, price, count_items, summa, document_id) VALUES (77, 37, '0,82р.', 4000.000, '3 280,00р.', 8);
INSERT INTO item_proposal (id, element_id, price, count_items, summa, document_id) VALUES (79, 38, '2,37р.', 4000.000, '9 480,00р.', 8);
INSERT INTO item_proposal (id, element_id, price, count_items, summa, document_id) VALUES (136, 6, '0,47р.', 24000.000, '11 280,00р.', 21);
INSERT INTO item_proposal (id, element_id, price, count_items, summa, document_id) VALUES (137, 7, '0,47р.', 24000.000, '11 280,00р.', 21);
INSERT INTO item_proposal (id, element_id, price, count_items, summa, document_id) VALUES (139, 34, '0,76р.', 6000.000, '4 560,00р.', 21);
INSERT INTO item_proposal (id, element_id, price, count_items, summa, document_id) VALUES (138, 35, '0,71р.', 28000.000, '19 880,00р.', 21);
INSERT INTO item_proposal (id, element_id, price, count_items, summa, document_id) VALUES (135, 38, '2,37р.', 6000.000, '14 220,00р.', 21);
INSERT INTO item_proposal (id, element_id, price, count_items, summa, document_id) VALUES (141, 37, '0,82р.', 4000.000, '3 280,00р.', 21);
INSERT INTO item_proposal (id, element_id, price, count_items, summa, document_id) VALUES (140, 46, '1,28р.', 2000.000, '2 560,00р.', 21);


--
-- TOC entry 2751 (class 0 OID 18178)
-- Dependencies: 206
-- Data for Name: item_specification; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2756 (class 0 OID 18204)
-- Dependencies: 211
-- Data for Name: item_tax; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO item_tax (id, element_id, price, count_items, summa, article_id, specification_id, source_id) VALUES (93, 1, '0,00р.', 5.100, '0,04р.', 4, 53, 3);
INSERT INTO item_tax (id, element_id, price, count_items, summa, article_id, specification_id, source_id) VALUES (94, 2, '0,00р.', 22.000, '0,17р.', 4, 53, 3);
INSERT INTO item_tax (id, element_id, price, count_items, summa, article_id, specification_id, source_id) VALUES (95, 5, '0,00р.', 1.300, '0,01р.', 4, 53, 3);
INSERT INTO item_tax (id, element_id, price, count_items, summa, article_id, specification_id, source_id) VALUES (96, 6, '0,00р.', 2.900, '0,02р.', 4, 53, 3);
INSERT INTO item_tax (id, element_id, price, count_items, summa, article_id, specification_id, source_id) VALUES (97, 7, '0,00р.', 100.000, '0,79р.', 5, 53, 3);
INSERT INTO item_tax (id, element_id, price, count_items, summa, article_id, specification_id, source_id) VALUES (98, 3, '0,00р.', 10.000, '0,29р.', 5, 53, 1);
INSERT INTO item_tax (id, element_id, price, count_items, summa, article_id, specification_id, source_id) VALUES (99, 4, '0,00р.', 5.000, '0,15р.', 5, 53, 1);
INSERT INTO item_tax (id, element_id, price, count_items, summa, article_id, specification_id, source_id) VALUES (132, 7, '0,00р.', 100.000, '5,63р.', 5, 54, 3);
INSERT INTO item_tax (id, element_id, price, count_items, summa, article_id, specification_id, source_id) VALUES (133, 3, '0,00р.', 10.000, '3,12р.', 5, 54, 1);
INSERT INTO item_tax (id, element_id, price, count_items, summa, article_id, specification_id, source_id) VALUES (134, 4, '0,00р.', 5.000, '1,56р.', 5, 54, 1);


--
-- TOC entry 2757 (class 0 OID 18210)
-- Dependencies: 212
-- Data for Name: material; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO material (id, name, measurement_id, price, tax_value, service, begin_remainder, min_order, group_id, image_id, article_code, alt_article_code, has_details) VALUES (3, 'Провод ПВАМ 0,5', 1, '2,05р.', 18, false, 0.000, 0.000, 23, NULL, NULL, NULL, true);
INSERT INTO material (id, name, measurement_id, price, tax_value, service, begin_remainder, min_order, group_id, image_id, article_code, alt_article_code, has_details) VALUES (4, 'Провод ПВАМ 0,75', 1, '3,14р.', 18, false, 0.000, 0.000, 23, NULL, NULL, NULL, true);
INSERT INTO material (id, name, measurement_id, price, tax_value, service, begin_remainder, min_order, group_id, image_id, article_code, alt_article_code, has_details) VALUES (7, 'Провод ПВАМ 1,0', 1, '4,18р.', 18, false, 0.000, 0.000, 23, NULL, NULL, NULL, true);
INSERT INTO material (id, name, measurement_id, price, tax_value, service, begin_remainder, min_order, group_id, image_id, article_code, alt_article_code, has_details) VALUES (8, 'Провод ПВАМ 1,5', 1, '7,01р.', 18, false, 0.000, 0.000, 23, NULL, NULL, NULL, true);
INSERT INTO material (id, name, measurement_id, price, tax_value, service, begin_remainder, min_order, group_id, image_id, article_code, alt_article_code, has_details) VALUES (9, 'Провод ПВАМ 2,5', 1, '9,98р.', 18, false, 0.000, 0.000, 23, NULL, NULL, NULL, true);
INSERT INTO material (id, name, measurement_id, price, tax_value, service, begin_remainder, min_order, group_id, image_id, article_code, alt_article_code, has_details) VALUES (10, 'Провод ПВАМ 4,0', 1, '16,13р.', 18, false, 0.000, 0.000, 23, NULL, NULL, NULL, true);
INSERT INTO material (id, name, measurement_id, price, tax_value, service, begin_remainder, min_order, group_id, image_id, article_code, alt_article_code, has_details) VALUES (15, 'Контакт колодочный 1/02505-01', 7, '0,71р.', 18, false, 0.000, 4000.000, 25, NULL, '1/02505-01', '4573738008/1', false);
INSERT INTO material (id, name, measurement_id, price, tax_value, service, begin_remainder, min_order, group_id, image_id, article_code, alt_article_code, has_details) VALUES (17, 'Наконечник проводов низкого напряжения 1/04046-01', 7, '0,82р.', 18, false, 0.000, 2000.000, 25, NULL, '1/04046-01', NULL, false);
INSERT INTO material (id, name, measurement_id, price, tax_value, service, begin_remainder, min_order, group_id, image_id, article_code, alt_article_code, has_details) VALUES (27, 'Контакт колодочный 1/02505-02', 7, '0,71р.', 18, false, 0.000, 4000.000, 25, NULL, '1/02505-02', '4573738008/2', false);
INSERT INTO material (id, name, measurement_id, price, tax_value, service, begin_remainder, min_order, group_id, image_id, article_code, alt_article_code, has_details) VALUES (1, 'Контакт колодочный 2108-3724391-01', 7, '0,47р.', 18, false, 0.000, 6000.000, 25, 13, '2108-3724391-01', '4573738865', false);
INSERT INTO material (id, name, measurement_id, price, tax_value, service, begin_remainder, min_order, group_id, image_id, article_code, alt_article_code, has_details) VALUES (2, 'Контакт колодочный 2108-3724391-02', 7, '0,47р.', 18, false, 0.000, 6000.000, 25, 13, '2108-3724391-02', '4573738845', false);
INSERT INTO material (id, name, measurement_id, price, tax_value, service, begin_remainder, min_order, group_id, image_id, article_code, alt_article_code, has_details) VALUES (14, 'Контакт колодочный 1/02506-01', 7, '0,76р.', 18, false, 0.000, 3000.000, 25, NULL, '1/02506-01', '4573738004/1', false);
INSERT INTO material (id, name, measurement_id, price, tax_value, service, begin_remainder, min_order, group_id, image_id, article_code, alt_article_code, has_details) VALUES (16, 'Контакт с фиксирующим элементом 1/02497-01', 7, '0,75р.', 18, false, 0.000, 4000.000, 25, 15, '1/02497-01', '4573738006/1', false);
INSERT INTO material (id, name, measurement_id, price, tax_value, service, begin_remainder, min_order, group_id, image_id, article_code, alt_article_code, has_details) VALUES (13, 'Наконечник 2108-3724392-01', 7, '0,74р.', 18, false, 0.000, 4000.000, 25, 17, '2108-3724392-01', '4573738891', false);
INSERT INTO material (id, name, measurement_id, price, tax_value, service, begin_remainder, min_order, group_id, image_id, article_code, alt_article_code, has_details) VALUES (18, 'Колодка гнездовая 2106-3724568-01', 7, '2,37р.', 18, false, 0.000, 2000.000, 24, 18, '2106-3724568-01', NULL, false);
INSERT INTO material (id, name, measurement_id, price, tax_value, service, begin_remainder, min_order, group_id, image_id, article_code, alt_article_code, has_details) VALUES (28, 'Колодка штыревая серии 6,3мм 1/20605', 7, '1,28р.', 18, false, 0.000, 2000.000, 24, NULL, '1/20605', '4573739004', false);


--
-- TOC entry 2758 (class 0 OID 18218)
-- Dependencies: 213
-- Data for Name: material_detail; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO material_detail (id, name, material_id) VALUES (1, 'Белый', 3);
INSERT INTO material_detail (id, name, material_id) VALUES (2, 'Черный', 3);
INSERT INTO material_detail (id, name, material_id) VALUES (3, 'Красный', 3);
INSERT INTO material_detail (id, name, material_id) VALUES (4, 'Зеленый', 3);
INSERT INTO material_detail (id, name, material_id) VALUES (5, 'Голубой', 3);
INSERT INTO material_detail (id, name, material_id) VALUES (6, 'Основной', 1);
INSERT INTO material_detail (id, name, material_id) VALUES (7, 'Основной', 2);
INSERT INTO material_detail (id, name, material_id) VALUES (11, 'Основной', 7);
INSERT INTO material_detail (id, name, material_id) VALUES (12, 'Основной', 8);
INSERT INTO material_detail (id, name, material_id) VALUES (13, 'Основной', 9);
INSERT INTO material_detail (id, name, material_id) VALUES (14, 'Основной', 10);
INSERT INTO material_detail (id, name, material_id) VALUES (33, 'Основной', 13);
INSERT INTO material_detail (id, name, material_id) VALUES (34, 'Основной', 14);
INSERT INTO material_detail (id, name, material_id) VALUES (35, 'Основной', 15);
INSERT INTO material_detail (id, name, material_id) VALUES (36, 'Основной', 16);
INSERT INTO material_detail (id, name, material_id) VALUES (37, 'Основной', 17);
INSERT INTO material_detail (id, name, material_id) VALUES (38, 'Основной', 18);
INSERT INTO material_detail (id, name, material_id) VALUES (41, 'Белый', 4);
INSERT INTO material_detail (id, name, material_id) VALUES (42, 'Красный', 4);
INSERT INTO material_detail (id, name, material_id) VALUES (43, 'Голубой', 4);
INSERT INTO material_detail (id, name, material_id) VALUES (44, 'Коричневый', 4);
INSERT INTO material_detail (id, name, material_id) VALUES (8, 'Черный', 4);
INSERT INTO material_detail (id, name, material_id) VALUES (45, 'Основной', 27);
INSERT INTO material_detail (id, name, material_id) VALUES (46, 'Основной', 28);


--
-- TOC entry 2872 (class 0 OID 0)
-- Dependencies: 214
-- Name: material_detail_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('material_detail_id_seq', 46, true);


--
-- TOC entry 2873 (class 0 OID 0)
-- Dependencies: 215
-- Name: material_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('material_id_seq', 28, true);


--
-- TOC entry 2761 (class 0 OID 18225)
-- Dependencies: 216
-- Data for Name: measurement; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO measurement (id, code, name, abbreviation, is_default) VALUES (2, 166, 'Килограмм', 'кг', false);
INSERT INTO measurement (id, code, name, abbreviation, is_default) VALUES (3, 168, 'Тонна', 'т', false);
INSERT INTO measurement (id, code, name, abbreviation, is_default) VALUES (4, 625, 'Лист', 'л', false);
INSERT INTO measurement (id, code, name, abbreviation, is_default) VALUES (5, 657, 'Изделие', 'изд', false);
INSERT INTO measurement (id, code, name, abbreviation, is_default) VALUES (6, 798, 'Тысяча штук', 'тыс. шт', false);
INSERT INTO measurement (id, code, name, abbreviation, is_default) VALUES (1, 6, 'Метр', 'м', false);
INSERT INTO measurement (id, code, name, abbreviation, is_default) VALUES (8, 778, 'Упаковка', 'упак', false);
INSERT INTO measurement (id, code, name, abbreviation, is_default) VALUES (7, 796, 'Штука', 'шт', true);


--
-- TOC entry 2874 (class 0 OID 0)
-- Dependencies: 217
-- Name: measurement_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('measurement_id_seq', 21, true);


--
-- TOC entry 2763 (class 0 OID 18232)
-- Dependencies: 218
-- Data for Name: numerator; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO numerator (id, name, document_number) VALUES (7, 'InvoiceIncome', 4);
INSERT INTO numerator (id, name, document_number) VALUES (9, 'InvoiceExpense', 1);
INSERT INTO numerator (id, name, document_number) VALUES (1, 'Proposal', 6);


--
-- TOC entry 2875 (class 0 OID 0)
-- Dependencies: 219
-- Name: numerator_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('numerator_id_seq', 9, true);


--
-- TOC entry 2765 (class 0 OID 18238)
-- Dependencies: 220
-- Data for Name: okopf; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO okopf (id, code, name) VALUES (1, 12247, 'Публичные акционерные общества');
INSERT INTO okopf (id, code, name) VALUES (2, 12300, 'Общество с ограниченной ответственностью');
INSERT INTO okopf (id, code, name) VALUES (3, 50102, 'Индивидуальные предприниматели');


--
-- TOC entry 2876 (class 0 OID 0)
-- Dependencies: 221
-- Name: okopf_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('okopf_id_seq', 3, true);


--
-- TOC entry 2767 (class 0 OID 18243)
-- Dependencies: 222
-- Data for Name: okpdtr; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO okpdtr (id, code, name, view_name) VALUES (1, 21374611210, 'Директор завода', NULL);
INSERT INTO okpdtr (id, code, name, view_name) VALUES (2, 21593411210, 'Директор фирмы', NULL);
INSERT INTO okpdtr (id, code, name, view_name) VALUES (3, 21495011210, 'Директор (начальник, управляющий) предприятия', NULL);
INSERT INTO okpdtr (id, code, name, view_name) VALUES (4, 20656411231, 'Главный бухгалтер', NULL);


--
-- TOC entry 2877 (class 0 OID 0)
-- Dependencies: 223
-- Name: okpdtr_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('okpdtr_id_seq', 4, true);


--
-- TOC entry 2769 (class 0 OID 18248)
-- Dependencies: 224
-- Data for Name: operation; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (1, 'Резка наконечников (размотка катушки)', '85,00р.', 1895, 0.045, NULL);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (2, 'Резка трубки L=24мм', '85,00р.', 1560, 0.054, NULL);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (3, 'Резка трубки L=440мм', '85,00р.', 1200, 0.071, NULL);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (20, 'Установка трубки на наконечник', '85,00р.', 750, 0.113, NULL);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (21, 'Нарезка изоленты', '85,00р.', 923, 0.092, NULL);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (22, 'Соединение проводов изолентой 3 места', '85,00р.', 118, 0.720, 2);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (23, 'Соединение проводов изолентой 6 мест', '85,00р.', 74, 1.149, 2);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (24, 'Соединение проводов изолентой 7 мест', '85,00р.', 67, 1.269, 2);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (25, 'Установка колодки одноконтактной 1/02505-02', '85,00р.', 600, 0.142, NULL);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (26, 'Установка в колодку 2106-3724568-01 всех проводов, визуальный контроль наконечников', '85,00р.', 29, 2.931, 2);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (27, 'Скрепление жгута изолентой 1 место', '85,00р.', 248, 0.343, 2);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (28, 'Скрепление жгута изолентой 3 места', '85,00р.', 90, 0.944, 2);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (29, 'Установка наконечника на проводе (пресс-клещи)', '85,00р.', 450, 0.189, NULL);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (30, 'Установка наконечника на 1 проводе сечением (пресс)', '85,00р.', 2400, 0.035, NULL);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (31, 'Установка 5 проводов в трубку ПВХ', '85,00р.', 67, 1.269, NULL);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (32, 'Упаковка', '85,00р.', 3600, 0.024, 2);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (33, 'Смотка в пучёк с фиксацией банковской резинкой', '85,00р.', 78, 1.090, 2);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (4, 'Резка провода L=100 мм', '85,00р.', 5557, 0.015, 1);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (5, 'Резка провода L=110 мм', '85,00р.', 5457, 0.016, 1);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (6, 'Резка провода L=150 мм', '85,00р.', 5092, 0.017, 1);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (17, 'Резка провода L=1570 мм', '85,00р.', 1508, 0.056, 1);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (18, 'Резка провода L=1650 мм', '85,00р.', 1450, 0.059, 1);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (7, 'Резка провода L=225 мм', '85,00р.', 4524, 0.019, 1);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (19, 'Резка провода L=2400 мм', '85,00р.', 1068, 0.080, 1);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (8, 'Резка провода L=245 мм', '85,00р.', 4393, 0.019, 1);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (9, 'Резка провода L=350 мм', '85,00р.', 3815, 0.022, 1);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (10, 'Резка провода L=450 мм', '85,00р.', 3390, 0.025, 1);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (11, 'Резка провода L=560 мм', '85,00р.', 3019, 0.028, 1);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (12, 'Резка провода L=580 мм', '85,00р.', 2961, 0.029, 1);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (13, 'Резка провода L=740 мм', '85,00р.', 2562, 0.033, 1);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (14, 'Резка провода L=830 мм', '85,00р.', 2381, 0.036, 1);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (15, 'Резка провода L=850 мм', '85,00р.', 2345, 0.036, 1);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (16, 'Резка провода L=860 мм', '85,00р.', 2327, 0.037, 1);
INSERT INTO operation (id, name, salary, time_rate, price, group_id) VALUES (34, 'Резка провода L=1350 мм', '85,00р.', 1692, 0.050, 1);


--
-- TOC entry 2878 (class 0 OID 0)
-- Dependencies: 225
-- Name: operation_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('operation_id_seq', 34, true);


--
-- TOC entry 2771 (class 0 OID 18256)
-- Dependencies: 226
-- Data for Name: person; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO person (id, name, first_name, middle_name, surname, phone, email, group_id) VALUES (22, 'Михайлов Г.', 'Геннадий', NULL, 'Михайлов', NULL, 'mgm@mpkabel.ru', NULL);
INSERT INTO person (id, name, first_name, middle_name, surname, phone, email, group_id) VALUES (2, 'Тепляшин С. В.', 'Сергей', 'Васильевич', 'Тепляшин', '(929) 792-54-94', 'sergio.teplyashin@gmail.com', NULL);
INSERT INTO person (id, name, first_name, middle_name, surname, phone, email, group_id) VALUES (21, 'Тепляшина О. А.', 'Оксана', 'Александровна', 'Тепляшина', '(927) 986-00-96', 'oksana.teplyashin@gmail.com', NULL);
INSERT INTO person (id, name, first_name, middle_name, surname, phone, email, group_id) VALUES (36, 'Сомихина Р. В.', 'Римма', 'Витальевна', 'Сомихина', NULL, NULL, NULL);


--
-- TOC entry 2879 (class 0 OID 0)
-- Dependencies: 227
-- Name: person_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('person_id_seq', 36, true);


--
-- TOC entry 2773 (class 0 OID 18261)
-- Dependencies: 228
-- Data for Name: product; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO product (id, name, article_code, full_name, specification_id) VALUES (19, 'Product1', NULL, NULL, NULL);
INSERT INTO product (id, name, article_code, full_name, specification_id) VALUES (20, 'Product2', NULL, NULL, NULL);
INSERT INTO product (id, name, article_code, full_name, specification_id) VALUES (21, 'Бабочка', NULL, NULL, 53);
INSERT INTO product (id, name, article_code, full_name, specification_id) VALUES (1, 'Провод 1118-3704103', '1118-3704103', '', NULL);
INSERT INTO product (id, name, article_code, full_name, specification_id) VALUES (22, 'Жгут стеклоподъемника (Барауля)', NULL, NULL, 54);


--
-- TOC entry 2880 (class 0 OID 0)
-- Dependencies: 229
-- Name: product_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('product_id_seq', 22, true);


--
-- TOC entry 2775 (class 0 OID 18266)
-- Dependencies: 230
-- Data for Name: proposal; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO proposal (id, accept, date_created, reference_number, summa, contractor_id, organization_id, date_send) VALUES (8, true, '2016-05-09 21:15:57', 3, '44 000,00р.', 12, 11, '2016-05-10 15:29:54');
INSERT INTO proposal (id, accept, date_created, reference_number, summa, contractor_id, organization_id, date_send) VALUES (21, true, '2016-09-23 07:42:54', 6, '67 060,00р.', 12, 11, NULL);


--
-- TOC entry 2776 (class 0 OID 18272)
-- Dependencies: 231
-- Data for Name: specification; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO specification (id, name, product_id, date_approval, comment_text, cost, profit, price, profit_percent, calc_price_method, tax_value, tax_summa, summa, is_default) VALUES (10, 'Основная', 1, '2016-05-03 09:19:20', '', '0,00р.', '0,00р.', '0,00р.', 20.0, 'profit', 18, '0,00р.', '0,00р.', false);
INSERT INTO specification (id, name, product_id, date_approval, comment_text, cost, profit, price, profit_percent, calc_price_method, tax_value, tax_summa, summa, is_default) VALUES (49, 'Spec1', 19, '2016-05-09 19:17:20', NULL, '0,00р.', '0,00р.', '0,00р.', 20.0, 'profit', 18, '0,00р.', '0,00р.', false);
INSERT INTO specification (id, name, product_id, date_approval, comment_text, cost, profit, price, profit_percent, calc_price_method, tax_value, tax_summa, summa, is_default) VALUES (51, 'Spec1', 20, '2016-05-09 19:17:31', NULL, '0,00р.', '0,00р.', '0,00р.', 20.0, 'profit', 18, '0,00р.', '0,00р.', false);
INSERT INTO specification (id, name, product_id, date_approval, comment_text, cost, profit, price, profit_percent, calc_price_method, tax_value, tax_summa, summa, is_default) VALUES (52, 'Spec2', 20, '2016-05-09 19:17:35', NULL, '0,00р.', '0,00р.', '0,00р.', 20.0, 'profit', 18, '0,00р.', '0,00р.', false);
INSERT INTO specification (id, name, product_id, date_approval, comment_text, cost, profit, price, profit_percent, calc_price_method, tax_value, tax_summa, summa, is_default) VALUES (53, 'Основная', 21, '2016-05-11 10:18:47', NULL, '5,19р.', '1,03р.', '6,22р.', 20.0, 'profit', 18, '1,11р.', '7,33р.', true);
INSERT INTO specification (id, name, product_id, date_approval, comment_text, cost, profit, price, profit_percent, calc_price_method, tax_value, tax_summa, summa, is_default) VALUES (50, 'Spec2', 19, '2016-05-08 19:17:27', NULL, '0,00р.', '0,00р.', '0,00р.', 20.0, 'profit', 18, '0,00р.', '0,00р.', false);
INSERT INTO specification (id, name, product_id, date_approval, comment_text, cost, profit, price, profit_percent, calc_price_method, tax_value, tax_summa, summa, is_default) VALUES (54, 'Основной', 22, '2016-09-21 12:22:51', NULL, '47,10р.', '9,42р.', '56,52р.', 20.0, 'profit', 18, '10,17р.', '66,69р.', true);
INSERT INTO specification (id, name, product_id, date_approval, comment_text, cost, profit, price, profit_percent, calc_price_method, tax_value, tax_summa, summa, is_default) VALUES (55, 'sss', 20, '2016-09-26 12:34:20', NULL, '0,00р.', '0,00р.', '0,00р.', 20.0, 'profit', 18, '0,00р.', '0,00р.', false);
INSERT INTO specification (id, name, product_id, date_approval, comment_text, cost, profit, price, profit_percent, calc_price_method, tax_value, tax_summa, summa, is_default) VALUES (56, 'ddd', 20, '2016-09-26 12:34:24', NULL, '0,00р.', '0,00р.', '0,00р.', 20.0, 'profit', 18, '0,00р.', '0,00р.', false);


--
-- TOC entry 2881 (class 0 OID 0)
-- Dependencies: 232
-- Name: specification_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('specification_id_seq', 56, true);


--
-- TOC entry 2778 (class 0 OID 18290)
-- Dependencies: 233
-- Data for Name: supplier; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO supplier (id, contractor_id, material_id, price) VALUES (16, 12, 14, '0,76р.');
INSERT INTO supplier (id, contractor_id, material_id, price) VALUES (17, 12, 16, '0,75р.');
INSERT INTO supplier (id, contractor_id, material_id, price) VALUES (13, 13, 4, '3,14р.');
INSERT INTO supplier (id, contractor_id, material_id, price) VALUES (12, 13, 9, '9,98р.');
INSERT INTO supplier (id, contractor_id, material_id, price) VALUES (23, 13, 3, '2,05р.');
INSERT INTO supplier (id, contractor_id, material_id, price) VALUES (24, 13, 7, '4,18р.');
INSERT INTO supplier (id, contractor_id, material_id, price) VALUES (25, 13, 8, '7,01р.');
INSERT INTO supplier (id, contractor_id, material_id, price) VALUES (26, 13, 10, '16,13р.');
INSERT INTO supplier (id, contractor_id, material_id, price) VALUES (19, 12, 18, '2,37р.');
INSERT INTO supplier (id, contractor_id, material_id, price) VALUES (9, 12, 1, '0,47р.');
INSERT INTO supplier (id, contractor_id, material_id, price) VALUES (14, 12, 2, '0,47р.');
INSERT INTO supplier (id, contractor_id, material_id, price) VALUES (15, 12, 15, '0,71р.');
INSERT INTO supplier (id, contractor_id, material_id, price) VALUES (18, 12, 17, '0,82р.');
INSERT INTO supplier (id, contractor_id, material_id, price) VALUES (20, 12, 13, '0,74р.');


--
-- TOC entry 2882 (class 0 OID 0)
-- Dependencies: 234
-- Name: supplier_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('supplier_id_seq', 26, true);


--
-- TOC entry 2780 (class 0 OID 18296)
-- Dependencies: 235
-- Data for Name: table_property; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (1, 'measurement', 'Еденицы измерения', false, false, false, false, false, true);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (2, 'tax', 'Налоги и отчисления', false, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (3, 'bank', 'Банки', false, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (4, 'okopf', 'ОКОПФ', false, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (5, 'okpdtr', 'ОКПДТР', false, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (7, 'operation', 'Технологические операции', true, false, false, true, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (8, 'specification', 'Спецификации', false, false, false, true, true, true);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (9, 'product', 'Изделия', false, true, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (10, 'employee', 'Сотрудники', true, false, true, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (11, 'supplier', 'Поставщики', true, false, true, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (12, 'contractor', 'Контрагенты', true, false, false, false, false, true);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (13, 'article', 'Статья спецификации', false, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (14, 'item_material', 'Материал', false, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (15, 'item_operation', 'Тех. операция', false, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (17, 'item_tax', 'Налог, отчисление', false, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (18, 'group_item', 'Группа', false, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (19, 'person', 'Физические лица', true, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (20, 'invoice_income', 'Приходные накладные', false, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (21, 'invoice_expense', 'Расходные накладные', false, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (22, 'proposal', 'Заявки', false, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (6, 'material', 'Материалы', true, false, false, false, false, true);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (24, 'material_detail', 'Материалы', true, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (23, 'item_proposal', 'Материалы', false, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (25, 'item_product', 'Изделия собств. производства', false, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (26, 'item_invoice_income', 'Материалы', false, false, false, false, false, false);
INSERT INTO table_property (id, name, title, has_group, has_child, show_all_root, refresh_current, refresh_master, refresh_before) VALUES (27, 'item_invoice_expense', 'Материалы', false, false, false, false, false, false);


--
-- TOC entry 2883 (class 0 OID 0)
-- Dependencies: 236
-- Name: table_property_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('table_property_id_seq', 27, true);


--
-- TOC entry 2782 (class 0 OID 18307)
-- Dependencies: 237
-- Data for Name: tax; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO tax (id, name, tax_value) VALUES (1, 'Федеральный фонд ОМС', 5.10);
INSERT INTO tax (id, name, tax_value) VALUES (2, 'Пенсионный фонд РФ', 22.00);
INSERT INTO tax (id, name, tax_value) VALUES (5, 'Расчеты по обязательному социальному страхованию от НСиПЗ', 1.30);
INSERT INTO tax (id, name, tax_value) VALUES (6, 'Расчеты по социальному страхованию', 2.90);
INSERT INTO tax (id, name, tax_value) VALUES (7, 'Накладные расходы', 100.00);
INSERT INTO tax (id, name, tax_value) VALUES (3, 'Транспортно-заготовительные расходы', 10.00);
INSERT INTO tax (id, name, tax_value) VALUES (4, 'Возмещение износа инструмента и оснастки', 5.00);


--
-- TOC entry 2884 (class 0 OID 0)
-- Dependencies: 238
-- Name: tax_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('tax_id_seq', 7, true);


--
-- TOC entry 2357 (class 2606 OID 18386)
-- Name: pk_id_article; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY article
    ADD CONSTRAINT pk_id_article PRIMARY KEY (id);


--
-- TOC entry 2361 (class 2606 OID 18388)
-- Name: pk_id_bank; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY bank
    ADD CONSTRAINT pk_id_bank PRIMARY KEY (id);


--
-- TOC entry 2371 (class 2606 OID 18390)
-- Name: pk_id_column_item; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY column_item
    ADD CONSTRAINT pk_id_column_item PRIMARY KEY (id);


--
-- TOC entry 2380 (class 2606 OID 18392)
-- Name: pk_id_contractor; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY contractor
    ADD CONSTRAINT pk_id_contractor PRIMARY KEY (id);


--
-- TOC entry 2388 (class 2606 OID 18394)
-- Name: pk_id_document; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY document
    ADD CONSTRAINT pk_id_document PRIMARY KEY (id);


--
-- TOC entry 2386 (class 2606 OID 18396)
-- Name: pk_id_document_common; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY document_common
    ADD CONSTRAINT pk_id_document_common PRIMARY KEY (id);


--
-- TOC entry 2393 (class 2606 OID 18398)
-- Name: pk_id_employee; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY employee
    ADD CONSTRAINT pk_id_employee PRIMARY KEY (id);


--
-- TOC entry 2397 (class 2606 OID 18400)
-- Name: pk_id_group_item; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY group_item
    ADD CONSTRAINT pk_id_group_item PRIMARY KEY (id);


--
-- TOC entry 2401 (class 2606 OID 18402)
-- Name: pk_id_image; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY image
    ADD CONSTRAINT pk_id_image PRIMARY KEY (id);


--
-- TOC entry 2403 (class 2606 OID 18404)
-- Name: pk_id_invoice; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice
    ADD CONSTRAINT pk_id_invoice PRIMARY KEY (id);


--
-- TOC entry 2405 (class 2606 OID 18406)
-- Name: pk_id_invoice_contractor; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_contractor
    ADD CONSTRAINT pk_id_invoice_contractor PRIMARY KEY (id);


--
-- TOC entry 2408 (class 2606 OID 18408)
-- Name: pk_id_invoice_expense; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_expense
    ADD CONSTRAINT pk_id_invoice_expense PRIMARY KEY (id);


--
-- TOC entry 2413 (class 2606 OID 18410)
-- Name: pk_id_invoice_income; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_income
    ADD CONSTRAINT pk_id_invoice_income PRIMARY KEY (id);


--
-- TOC entry 2417 (class 2606 OID 18412)
-- Name: pk_id_invoice_write_off; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_write_off
    ADD CONSTRAINT pk_id_invoice_write_off PRIMARY KEY (id);


--
-- TOC entry 2419 (class 2606 OID 18414)
-- Name: pk_id_item; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item
    ADD CONSTRAINT pk_id_item PRIMARY KEY (id);


--
-- TOC entry 2421 (class 2606 OID 18416)
-- Name: pk_id_item_document; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_document
    ADD CONSTRAINT pk_id_item_document PRIMARY KEY (id);


--
-- TOC entry 2531 (class 2606 OID 18821)
-- Name: pk_id_item_invoice_expense; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_invoice_expense
    ADD CONSTRAINT pk_id_item_invoice_expense PRIMARY KEY (id);


--
-- TOC entry 2525 (class 2606 OID 18784)
-- Name: pk_id_item_invoice_income; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_invoice_income
    ADD CONSTRAINT pk_id_item_invoice_income PRIMARY KEY (id);


--
-- TOC entry 2428 (class 2606 OID 18418)
-- Name: pk_id_item_material; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_material
    ADD CONSTRAINT pk_id_item_material PRIMARY KEY (id);


--
-- TOC entry 2435 (class 2606 OID 18420)
-- Name: pk_id_item_operation; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_operation
    ADD CONSTRAINT pk_id_item_operation PRIMARY KEY (id);


--
-- TOC entry 2442 (class 2606 OID 18422)
-- Name: pk_id_item_product; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_product
    ADD CONSTRAINT pk_id_item_product PRIMARY KEY (id);


--
-- TOC entry 2448 (class 2606 OID 18424)
-- Name: pk_id_item_proposal; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_proposal
    ADD CONSTRAINT pk_id_item_proposal PRIMARY KEY (id);


--
-- TOC entry 2423 (class 2606 OID 18426)
-- Name: pk_id_item_specification; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_specification
    ADD CONSTRAINT pk_id_item_specification PRIMARY KEY (id);


--
-- TOC entry 2456 (class 2606 OID 18428)
-- Name: pk_id_item_tax; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_tax
    ADD CONSTRAINT pk_id_item_tax PRIMARY KEY (id);


--
-- TOC entry 2463 (class 2606 OID 18430)
-- Name: pk_id_material; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY material
    ADD CONSTRAINT pk_id_material PRIMARY KEY (id);


--
-- TOC entry 2468 (class 2606 OID 18432)
-- Name: pk_id_material_detail; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY material_detail
    ADD CONSTRAINT pk_id_material_detail PRIMARY KEY (id);


--
-- TOC entry 2472 (class 2606 OID 18434)
-- Name: pk_id_measurement; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY measurement
    ADD CONSTRAINT pk_id_measurement PRIMARY KEY (id);


--
-- TOC entry 2476 (class 2606 OID 18436)
-- Name: pk_id_numerator; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY numerator
    ADD CONSTRAINT pk_id_numerator PRIMARY KEY (id);


--
-- TOC entry 2478 (class 2606 OID 18438)
-- Name: pk_id_okopf; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY okopf
    ADD CONSTRAINT pk_id_okopf PRIMARY KEY (id);


--
-- TOC entry 2482 (class 2606 OID 18440)
-- Name: pk_id_okpdtr; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY okpdtr
    ADD CONSTRAINT pk_id_okpdtr PRIMARY KEY (id);


--
-- TOC entry 2487 (class 2606 OID 18442)
-- Name: pk_id_operation; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY operation
    ADD CONSTRAINT pk_id_operation PRIMARY KEY (id);


--
-- TOC entry 2492 (class 2606 OID 18444)
-- Name: pk_id_person; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY person
    ADD CONSTRAINT pk_id_person PRIMARY KEY (id);


--
-- TOC entry 2495 (class 2606 OID 18446)
-- Name: pk_id_product; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY product
    ADD CONSTRAINT pk_id_product PRIMARY KEY (id);


--
-- TOC entry 2501 (class 2606 OID 18448)
-- Name: pk_id_proposal; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY proposal
    ADD CONSTRAINT pk_id_proposal PRIMARY KEY (id);


--
-- TOC entry 2505 (class 2606 OID 18450)
-- Name: pk_id_specification; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY specification
    ADD CONSTRAINT pk_id_specification PRIMARY KEY (id);


--
-- TOC entry 2511 (class 2606 OID 18452)
-- Name: pk_id_supplier; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY supplier
    ADD CONSTRAINT pk_id_supplier PRIMARY KEY (id);


--
-- TOC entry 2515 (class 2606 OID 18454)
-- Name: pk_id_table_property; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY table_property
    ADD CONSTRAINT pk_id_table_property PRIMARY KEY (id);


--
-- TOC entry 2519 (class 2606 OID 18456)
-- Name: pk_id_tax; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY tax
    ADD CONSTRAINT pk_id_tax PRIMARY KEY (id);


--
-- TOC entry 2363 (class 2606 OID 18458)
-- Name: unq_account_bank; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY bank
    ADD CONSTRAINT unq_account_bank UNIQUE (account);


--
-- TOC entry 2365 (class 2606 OID 18460)
-- Name: unq_bik_bank; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY bank
    ADD CONSTRAINT unq_bik_bank UNIQUE (bik);


--
-- TOC entry 2474 (class 2606 OID 18462)
-- Name: unq_code_measurement; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY measurement
    ADD CONSTRAINT unq_code_measurement UNIQUE (code);


--
-- TOC entry 2480 (class 2606 OID 18464)
-- Name: unq_code_okopf; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY okopf
    ADD CONSTRAINT unq_code_okopf UNIQUE (code);


--
-- TOC entry 2484 (class 2606 OID 18466)
-- Name: unq_code_okpdtr; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY okpdtr
    ADD CONSTRAINT unq_code_okpdtr UNIQUE (code);


--
-- TOC entry 2373 (class 2606 OID 18468)
-- Name: unq_index_column_item; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY column_item
    ADD CONSTRAINT unq_index_column_item UNIQUE (table_id, index);


--
-- TOC entry 2382 (class 2606 OID 18470)
-- Name: unq_inn_contractor; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY contractor
    ADD CONSTRAINT unq_inn_contractor UNIQUE (inn);


--
-- TOC entry 2533 (class 2606 OID 18835)
-- Name: unq_item_invoice_expense; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_invoice_expense
    ADD CONSTRAINT unq_item_invoice_expense UNIQUE (document_id, element_id);


--
-- TOC entry 2527 (class 2606 OID 18798)
-- Name: unq_item_invoice_income; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_invoice_income
    ADD CONSTRAINT unq_item_invoice_income UNIQUE (document_id, element_id);


--
-- TOC entry 2450 (class 2606 OID 18472)
-- Name: unq_item_proposal; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_proposal
    ADD CONSTRAINT unq_item_proposal UNIQUE (document_id, element_id);


--
-- TOC entry 2430 (class 2606 OID 18474)
-- Name: unq_material_specification; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_material
    ADD CONSTRAINT unq_material_specification UNIQUE (element_id, specification_id);


--
-- TOC entry 2513 (class 2606 OID 18476)
-- Name: unq_material_supplier; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY supplier
    ADD CONSTRAINT unq_material_supplier UNIQUE (contractor_id, material_id);


--
-- TOC entry 2359 (class 2606 OID 18478)
-- Name: unq_name_article; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY article
    ADD CONSTRAINT unq_name_article UNIQUE (name);


--
-- TOC entry 2367 (class 2606 OID 18480)
-- Name: unq_name_bank; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY bank
    ADD CONSTRAINT unq_name_bank UNIQUE (name);


--
-- TOC entry 2375 (class 2606 OID 18482)
-- Name: unq_name_column_item; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY column_item
    ADD CONSTRAINT unq_name_column_item UNIQUE (table_id, name);


--
-- TOC entry 2384 (class 2606 OID 18484)
-- Name: unq_name_contractor; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY contractor
    ADD CONSTRAINT unq_name_contractor UNIQUE (name);


--
-- TOC entry 2399 (class 2606 OID 18486)
-- Name: unq_name_group_item; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY group_item
    ADD CONSTRAINT unq_name_group_item UNIQUE (table_id, name);


--
-- TOC entry 2465 (class 2606 OID 18488)
-- Name: unq_name_material; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY material
    ADD CONSTRAINT unq_name_material UNIQUE (name);


--
-- TOC entry 2470 (class 2606 OID 18490)
-- Name: unq_name_material_detail; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY material_detail
    ADD CONSTRAINT unq_name_material_detail UNIQUE (material_id, name);


--
-- TOC entry 2489 (class 2606 OID 18492)
-- Name: unq_name_operation; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY operation
    ADD CONSTRAINT unq_name_operation UNIQUE (name);


--
-- TOC entry 2497 (class 2606 OID 18494)
-- Name: unq_name_product; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY product
    ADD CONSTRAINT unq_name_product UNIQUE (name);


--
-- TOC entry 2507 (class 2606 OID 18496)
-- Name: unq_name_specification; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY specification
    ADD CONSTRAINT unq_name_specification UNIQUE (product_id, name);


--
-- TOC entry 2517 (class 2606 OID 18498)
-- Name: unq_name_table_property; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY table_property
    ADD CONSTRAINT unq_name_table_property UNIQUE (name);


--
-- TOC entry 2521 (class 2606 OID 18500)
-- Name: unq_name_tax; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY tax
    ADD CONSTRAINT unq_name_tax UNIQUE (name);


--
-- TOC entry 2437 (class 2606 OID 18502)
-- Name: unq_operation_specification; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_operation
    ADD CONSTRAINT unq_operation_specification UNIQUE (element_id, specification_id);


--
-- TOC entry 2444 (class 2606 OID 18504)
-- Name: unq_product_specification; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_product
    ADD CONSTRAINT unq_product_specification UNIQUE (element_id, specification_id);


--
-- TOC entry 2410 (class 2606 OID 18813)
-- Name: unq_ref_number_invoice_expense; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_expense
    ADD CONSTRAINT unq_ref_number_invoice_expense UNIQUE (reference_number);


--
-- TOC entry 2415 (class 2606 OID 18811)
-- Name: unq_ref_number_invoice_income; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_income
    ADD CONSTRAINT unq_ref_number_invoice_income UNIQUE (reference_number);


--
-- TOC entry 2503 (class 2606 OID 18809)
-- Name: unq_ref_number_proposal; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY proposal
    ADD CONSTRAINT unq_ref_number_proposal UNIQUE (reference_number);


--
-- TOC entry 2458 (class 2606 OID 18506)
-- Name: unq_tax_specification; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_tax
    ADD CONSTRAINT unq_tax_specification UNIQUE (element_id, specification_id);


--
-- TOC entry 2424 (class 1259 OID 18507)
-- Name: fki_article_item_material; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_article_item_material ON item_material USING btree (article_id);


--
-- TOC entry 2431 (class 1259 OID 18508)
-- Name: fki_article_item_operation; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_article_item_operation ON item_operation USING btree (article_id);


--
-- TOC entry 2438 (class 1259 OID 18509)
-- Name: fki_article_item_product; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_article_item_product ON item_product USING btree (article_id);


--
-- TOC entry 2451 (class 1259 OID 18510)
-- Name: fki_article_item_tax; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_article_item_tax ON item_tax USING btree (article_id);


--
-- TOC entry 2376 (class 1259 OID 18511)
-- Name: fki_bank_contractor; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_bank_contractor ON contractor USING btree (bank_id);


--
-- TOC entry 2389 (class 1259 OID 18512)
-- Name: fki_contractor_employee; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_contractor_employee ON employee USING btree (contractor_id);


--
-- TOC entry 2406 (class 1259 OID 18513)
-- Name: fki_contractor_invoice_expense; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_contractor_invoice_expense ON invoice_expense USING btree (contractor_id);


--
-- TOC entry 2411 (class 1259 OID 18514)
-- Name: fki_contractor_invoice_income; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_contractor_invoice_income ON invoice_income USING btree (contractor_id);


--
-- TOC entry 2498 (class 1259 OID 18515)
-- Name: fki_contractor_proposal; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_contractor_proposal ON proposal USING btree (contractor_id);


--
-- TOC entry 2508 (class 1259 OID 18516)
-- Name: fki_contractor_supplier; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_contractor_supplier ON supplier USING btree (contractor_id);


--
-- TOC entry 2528 (class 1259 OID 18827)
-- Name: fki_document_item_invoice_expense; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_document_item_invoice_expense ON item_invoice_expense USING btree (document_id);


--
-- TOC entry 2522 (class 1259 OID 18790)
-- Name: fki_document_item_invoice_income; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_document_item_invoice_income ON item_invoice_income USING btree (document_id);


--
-- TOC entry 2445 (class 1259 OID 18517)
-- Name: fki_document_item_proposal; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_document_item_proposal ON item_proposal USING btree (document_id);


--
-- TOC entry 2377 (class 1259 OID 18518)
-- Name: fki_group_contractor; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_group_contractor ON contractor USING btree (group_id);


--
-- TOC entry 2459 (class 1259 OID 18519)
-- Name: fki_group_material; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_group_material ON material USING btree (group_id);


--
-- TOC entry 2485 (class 1259 OID 18520)
-- Name: fki_group_operation; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_group_operation ON operation USING btree (group_id);


--
-- TOC entry 2490 (class 1259 OID 18521)
-- Name: fki_group_person; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_group_person ON person USING btree (group_id);


--
-- TOC entry 2460 (class 1259 OID 18522)
-- Name: fki_image_material; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_image_material ON material USING btree (image_id);


--
-- TOC entry 2466 (class 1259 OID 18523)
-- Name: fki_material_detail; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_material_detail ON material_detail USING btree (material_id);


--
-- TOC entry 2529 (class 1259 OID 18833)
-- Name: fki_material_item_invoice_expense; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_material_item_invoice_expense ON item_invoice_expense USING btree (element_id);


--
-- TOC entry 2523 (class 1259 OID 18796)
-- Name: fki_material_item_invoice_income; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_material_item_invoice_income ON item_invoice_income USING btree (element_id);


--
-- TOC entry 2425 (class 1259 OID 18524)
-- Name: fki_material_item_material; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_material_item_material ON item_material USING btree (element_id);


--
-- TOC entry 2446 (class 1259 OID 18525)
-- Name: fki_material_item_proposal; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_material_item_proposal ON item_proposal USING btree (element_id);


--
-- TOC entry 2509 (class 1259 OID 18526)
-- Name: fki_material_supplier; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_material_supplier ON supplier USING btree (material_id);


--
-- TOC entry 2461 (class 1259 OID 18527)
-- Name: fki_measurement_material; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_measurement_material ON material USING btree (measurement_id);


--
-- TOC entry 2378 (class 1259 OID 18528)
-- Name: fki_okopf_contractor; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_okopf_contractor ON contractor USING btree (okopf_id);


--
-- TOC entry 2432 (class 1259 OID 18529)
-- Name: fki_operation_item_operation; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_operation_item_operation ON item_operation USING btree (element_id);


--
-- TOC entry 2499 (class 1259 OID 18776)
-- Name: fki_organization_proposal; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_organization_proposal ON proposal USING btree (organization_id);


--
-- TOC entry 2394 (class 1259 OID 18530)
-- Name: fki_parent_group_item; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_parent_group_item ON group_item USING btree (parent_id);


--
-- TOC entry 2390 (class 1259 OID 18531)
-- Name: fki_person_employee; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_person_employee ON employee USING btree (person_id);


--
-- TOC entry 2391 (class 1259 OID 18532)
-- Name: fki_post_employee; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_post_employee ON employee USING btree (post_id);


--
-- TOC entry 2439 (class 1259 OID 18533)
-- Name: fki_product_item_product; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_product_item_product ON item_product USING btree (element_id);


--
-- TOC entry 2368 (class 1259 OID 18534)
-- Name: fki_source_column_item; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_source_column_item ON column_item USING btree (source_id);


--
-- TOC entry 2452 (class 1259 OID 18535)
-- Name: fki_source_item_tax; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_source_item_tax ON item_tax USING btree (source_id);


--
-- TOC entry 2426 (class 1259 OID 18536)
-- Name: fki_specification_item_material; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_specification_item_material ON item_material USING btree (specification_id);


--
-- TOC entry 2433 (class 1259 OID 18537)
-- Name: fki_specification_item_operation; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_specification_item_operation ON item_operation USING btree (specification_id);


--
-- TOC entry 2440 (class 1259 OID 18538)
-- Name: fki_specification_item_product; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_specification_item_product ON item_product USING btree (specification_id);


--
-- TOC entry 2453 (class 1259 OID 18539)
-- Name: fki_specification_item_tax; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_specification_item_tax ON item_tax USING btree (specification_id);


--
-- TOC entry 2493 (class 1259 OID 18540)
-- Name: fki_specification_product; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_specification_product ON product USING btree (specification_id);


--
-- TOC entry 2369 (class 1259 OID 18541)
-- Name: fki_table_column_item; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_table_column_item ON column_item USING btree (table_id);


--
-- TOC entry 2395 (class 1259 OID 18542)
-- Name: fki_table_group_item; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_table_group_item ON group_item USING btree (table_id);


--
-- TOC entry 2454 (class 1259 OID 18543)
-- Name: fki_tax_item_tax; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX fki_tax_item_tax ON item_tax USING btree (element_id);


--
-- TOC entry 2577 (class 2620 OID 18544)
-- Name: bank_biu; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER bank_biu BEFORE INSERT OR UPDATE ON bank FOR EACH ROW EXECUTE PROCEDURE test_bank_codes();


--
-- TOC entry 2578 (class 2620 OID 18545)
-- Name: contractor_biu0; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER contractor_biu0 BEFORE INSERT OR UPDATE ON contractor FOR EACH ROW EXECUTE PROCEDURE test_contractor_codes();


--
-- TOC entry 2579 (class 2620 OID 18546)
-- Name: contractor_biu1; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER contractor_biu1 BEFORE INSERT OR UPDATE ON contractor FOR EACH ROW EXECUTE PROCEDURE check_group();


--
-- TOC entry 2611 (class 2620 OID 18838)
-- Name: item_invoice_expense_aiud; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_invoice_expense_aiud AFTER INSERT OR DELETE OR UPDATE ON item_invoice_expense FOR EACH ROW EXECUTE PROCEDURE update_document_summa();


--
-- TOC entry 2609 (class 2620 OID 18836)
-- Name: item_invoice_expense_bi; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_invoice_expense_bi BEFORE INSERT ON item_invoice_expense FOR EACH ROW EXECUTE PROCEDURE set_price_item_material();


--
-- TOC entry 2610 (class 2620 OID 18837)
-- Name: item_invoice_expense_bu; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_invoice_expense_bu BEFORE UPDATE ON item_invoice_expense FOR EACH ROW EXECUTE PROCEDURE update_summa();


--
-- TOC entry 2608 (class 2620 OID 18801)
-- Name: item_invoice_income_aiud; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_invoice_income_aiud AFTER INSERT OR DELETE OR UPDATE ON item_invoice_income FOR EACH ROW EXECUTE PROCEDURE update_document_summa();


--
-- TOC entry 2606 (class 2620 OID 18799)
-- Name: item_invoice_income_bi; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_invoice_income_bi BEFORE INSERT ON item_invoice_income FOR EACH ROW EXECUTE PROCEDURE set_price_item_material();


--
-- TOC entry 2607 (class 2620 OID 18800)
-- Name: item_invoice_income_bu; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_invoice_income_bu BEFORE UPDATE ON item_invoice_income FOR EACH ROW EXECUTE PROCEDURE update_summa();


--
-- TOC entry 2580 (class 2620 OID 18547)
-- Name: item_material_aiud; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_material_aiud AFTER INSERT OR DELETE OR UPDATE ON item_material FOR EACH ROW EXECUTE PROCEDURE update_specification_price();


--
-- TOC entry 2581 (class 2620 OID 18548)
-- Name: item_material_bi; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_material_bi BEFORE INSERT ON item_material FOR EACH ROW EXECUTE PROCEDURE set_price_item_material();


--
-- TOC entry 2582 (class 2620 OID 18549)
-- Name: item_material_bu; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_material_bu BEFORE UPDATE ON item_material FOR EACH ROW EXECUTE PROCEDURE update_summa();


--
-- TOC entry 2583 (class 2620 OID 18550)
-- Name: item_oparation_bu; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_oparation_bu BEFORE UPDATE ON item_operation FOR EACH ROW EXECUTE PROCEDURE update_summa();


--
-- TOC entry 2584 (class 2620 OID 18551)
-- Name: item_operation_aiud; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_operation_aiud AFTER INSERT OR DELETE OR UPDATE ON item_operation FOR EACH ROW EXECUTE PROCEDURE update_specification_price();


--
-- TOC entry 2585 (class 2620 OID 18552)
-- Name: item_operation_bi; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_operation_bi BEFORE INSERT ON item_operation FOR EACH ROW EXECUTE PROCEDURE set_price_item_operation();


--
-- TOC entry 2586 (class 2620 OID 18553)
-- Name: item_product_aiud; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_product_aiud AFTER INSERT OR DELETE OR UPDATE ON item_product FOR EACH ROW EXECUTE PROCEDURE update_specification_price();


--
-- TOC entry 2587 (class 2620 OID 18554)
-- Name: item_product_bi0; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_product_bi0 BEFORE INSERT ON item_product FOR EACH ROW EXECUTE PROCEDURE check_item_product_specification();


--
-- TOC entry 2588 (class 2620 OID 18555)
-- Name: item_product_bi1; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_product_bi1 BEFORE INSERT ON item_product FOR EACH ROW EXECUTE PROCEDURE set_price_item_product();


--
-- TOC entry 2589 (class 2620 OID 18556)
-- Name: item_product_bu; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_product_bu BEFORE UPDATE ON item_product FOR EACH ROW EXECUTE PROCEDURE update_summa();


--
-- TOC entry 2590 (class 2620 OID 18557)
-- Name: item_proposal_aiud; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_proposal_aiud AFTER INSERT OR DELETE OR UPDATE ON item_proposal FOR EACH ROW EXECUTE PROCEDURE update_document_summa();


--
-- TOC entry 2591 (class 2620 OID 18558)
-- Name: item_proposal_bi; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_proposal_bi BEFORE INSERT ON item_proposal FOR EACH ROW EXECUTE PROCEDURE set_price_item_material();


--
-- TOC entry 2592 (class 2620 OID 18559)
-- Name: item_proposal_bu; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_proposal_bu BEFORE UPDATE ON item_proposal FOR EACH ROW EXECUTE PROCEDURE update_summa();


--
-- TOC entry 2593 (class 2620 OID 18560)
-- Name: item_tax_aiud; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_tax_aiud AFTER INSERT OR DELETE OR UPDATE ON item_tax FOR EACH ROW EXECUTE PROCEDURE update_specification_price();


--
-- TOC entry 2594 (class 2620 OID 18561)
-- Name: item_tax_bi; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_tax_bi BEFORE INSERT ON item_tax FOR EACH ROW EXECUTE PROCEDURE set_price_item_tax();


--
-- TOC entry 2595 (class 2620 OID 18562)
-- Name: item_tax_bu; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER item_tax_bu BEFORE UPDATE ON item_tax FOR EACH ROW EXECUTE PROCEDURE update_tax_summa_item();


--
-- TOC entry 2596 (class 2620 OID 18563)
-- Name: material_ai; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER material_ai AFTER INSERT ON material FOR EACH ROW EXECUTE PROCEDURE create_default_material_detail();


--
-- TOC entry 2597 (class 2620 OID 18564)
-- Name: material_biu; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER material_biu BEFORE INSERT OR UPDATE ON material FOR EACH ROW EXECUTE PROCEDURE check_group();


--
-- TOC entry 2598 (class 2620 OID 18565)
-- Name: measurement_biu; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER measurement_biu BEFORE INSERT OR UPDATE ON measurement FOR EACH ROW EXECUTE PROCEDURE clear_default_measurement();


--
-- TOC entry 2599 (class 2620 OID 18566)
-- Name: operation_biu0; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER operation_biu0 BEFORE INSERT OR UPDATE ON operation FOR EACH ROW EXECUTE PROCEDURE calculate_price_operation();


--
-- TOC entry 2600 (class 2620 OID 18567)
-- Name: operation_biu1; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER operation_biu1 BEFORE INSERT OR UPDATE ON operation FOR EACH ROW EXECUTE PROCEDURE check_group();


--
-- TOC entry 2601 (class 2620 OID 18568)
-- Name: person_biu; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER person_biu BEFORE INSERT OR UPDATE ON person FOR EACH ROW EXECUTE PROCEDURE check_group();


--
-- TOC entry 2602 (class 2620 OID 18569)
-- Name: specification_aiu0; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER specification_aiu0 AFTER INSERT OR UPDATE ON specification FOR EACH ROW EXECUTE PROCEDURE update_default_specification();


--
-- TOC entry 2603 (class 2620 OID 18570)
-- Name: specification_biu0; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER specification_biu0 BEFORE INSERT OR UPDATE ON specification FOR EACH ROW EXECUTE PROCEDURE clear_default_specification();


--
-- TOC entry 2604 (class 2620 OID 18571)
-- Name: specification_biu1; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER specification_biu1 BEFORE INSERT OR UPDATE ON specification FOR EACH ROW EXECUTE PROCEDURE calculate_price_specification();


--
-- TOC entry 2605 (class 2620 OID 18572)
-- Name: supplier_bi; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER supplier_bi BEFORE INSERT ON supplier FOR EACH ROW EXECUTE PROCEDURE define_material_price();


--
-- TOC entry 2546 (class 2606 OID 18573)
-- Name: fk_article_item_material; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_material
    ADD CONSTRAINT fk_article_item_material FOREIGN KEY (article_id) REFERENCES article(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2549 (class 2606 OID 18578)
-- Name: fk_article_item_operation; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_operation
    ADD CONSTRAINT fk_article_item_operation FOREIGN KEY (article_id) REFERENCES article(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2552 (class 2606 OID 18583)
-- Name: fk_article_item_product; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_product
    ADD CONSTRAINT fk_article_item_product FOREIGN KEY (article_id) REFERENCES article(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2557 (class 2606 OID 18588)
-- Name: fk_article_item_tax; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_tax
    ADD CONSTRAINT fk_article_item_tax FOREIGN KEY (article_id) REFERENCES article(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2536 (class 2606 OID 18593)
-- Name: fk_bank_contractor; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY contractor
    ADD CONSTRAINT fk_bank_contractor FOREIGN KEY (bank_id) REFERENCES bank(id) ON UPDATE CASCADE ON DELETE SET NULL;


--
-- TOC entry 2539 (class 2606 OID 18598)
-- Name: fk_contractor_employee; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY employee
    ADD CONSTRAINT fk_contractor_employee FOREIGN KEY (contractor_id) REFERENCES contractor(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2544 (class 2606 OID 18603)
-- Name: fk_contractor_invoice_expense; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_expense
    ADD CONSTRAINT fk_contractor_invoice_expense FOREIGN KEY (contractor_id) REFERENCES contractor(id) ON UPDATE CASCADE;


--
-- TOC entry 2545 (class 2606 OID 18608)
-- Name: fk_contractor_invoice_income; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY invoice_income
    ADD CONSTRAINT fk_contractor_invoice_income FOREIGN KEY (contractor_id) REFERENCES contractor(id) ON UPDATE CASCADE;


--
-- TOC entry 2568 (class 2606 OID 18613)
-- Name: fk_contractor_proposal; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY proposal
    ADD CONSTRAINT fk_contractor_proposal FOREIGN KEY (contractor_id) REFERENCES contractor(id) ON UPDATE CASCADE;


--
-- TOC entry 2571 (class 2606 OID 18618)
-- Name: fk_contractor_supplier; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY supplier
    ADD CONSTRAINT fk_contractor_supplier FOREIGN KEY (contractor_id) REFERENCES contractor(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2575 (class 2606 OID 18822)
-- Name: fk_document_item_invoice_expense; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_invoice_expense
    ADD CONSTRAINT fk_document_item_invoice_expense FOREIGN KEY (document_id) REFERENCES invoice_expense(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2573 (class 2606 OID 18785)
-- Name: fk_document_item_invoice_income; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_invoice_income
    ADD CONSTRAINT fk_document_item_invoice_income FOREIGN KEY (document_id) REFERENCES invoice_income(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2555 (class 2606 OID 18623)
-- Name: fk_document_item_proposal; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_proposal
    ADD CONSTRAINT fk_document_item_proposal FOREIGN KEY (document_id) REFERENCES proposal(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2537 (class 2606 OID 18628)
-- Name: fk_group_contractor; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY contractor
    ADD CONSTRAINT fk_group_contractor FOREIGN KEY (group_id) REFERENCES group_item(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2561 (class 2606 OID 18633)
-- Name: fk_group_material; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY material
    ADD CONSTRAINT fk_group_material FOREIGN KEY (group_id) REFERENCES group_item(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2565 (class 2606 OID 18638)
-- Name: fk_group_operation; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY operation
    ADD CONSTRAINT fk_group_operation FOREIGN KEY (group_id) REFERENCES group_item(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2566 (class 2606 OID 18643)
-- Name: fk_group_person; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY person
    ADD CONSTRAINT fk_group_person FOREIGN KEY (group_id) REFERENCES group_item(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2562 (class 2606 OID 18648)
-- Name: fk_image_material; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY material
    ADD CONSTRAINT fk_image_material FOREIGN KEY (image_id) REFERENCES image(id) ON UPDATE CASCADE ON DELETE SET NULL;


--
-- TOC entry 2564 (class 2606 OID 18653)
-- Name: fk_material_detail; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY material_detail
    ADD CONSTRAINT fk_material_detail FOREIGN KEY (material_id) REFERENCES material(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2576 (class 2606 OID 18828)
-- Name: fk_material_item_invoice_expense; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_invoice_expense
    ADD CONSTRAINT fk_material_item_invoice_expense FOREIGN KEY (element_id) REFERENCES material_detail(id) ON UPDATE CASCADE;


--
-- TOC entry 2574 (class 2606 OID 18791)
-- Name: fk_material_item_invoice_income; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_invoice_income
    ADD CONSTRAINT fk_material_item_invoice_income FOREIGN KEY (element_id) REFERENCES material_detail(id) ON UPDATE CASCADE;


--
-- TOC entry 2547 (class 2606 OID 18658)
-- Name: fk_material_item_material; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_material
    ADD CONSTRAINT fk_material_item_material FOREIGN KEY (element_id) REFERENCES material_detail(id) ON UPDATE CASCADE;


--
-- TOC entry 2556 (class 2606 OID 18663)
-- Name: fk_material_item_proposal; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_proposal
    ADD CONSTRAINT fk_material_item_proposal FOREIGN KEY (element_id) REFERENCES material_detail(id) ON UPDATE CASCADE;


--
-- TOC entry 2572 (class 2606 OID 18668)
-- Name: fk_material_supplier; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY supplier
    ADD CONSTRAINT fk_material_supplier FOREIGN KEY (material_id) REFERENCES material(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2563 (class 2606 OID 18673)
-- Name: fk_measurement_material; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY material
    ADD CONSTRAINT fk_measurement_material FOREIGN KEY (measurement_id) REFERENCES measurement(id) ON UPDATE CASCADE ON DELETE SET NULL;


--
-- TOC entry 2538 (class 2606 OID 18678)
-- Name: fk_okopf_contractor; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY contractor
    ADD CONSTRAINT fk_okopf_contractor FOREIGN KEY (okopf_id) REFERENCES okopf(id) ON UPDATE CASCADE ON DELETE SET NULL;


--
-- TOC entry 2550 (class 2606 OID 18683)
-- Name: fk_operation_item_operation; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_operation
    ADD CONSTRAINT fk_operation_item_operation FOREIGN KEY (element_id) REFERENCES operation(id) ON UPDATE CASCADE;


--
-- TOC entry 2569 (class 2606 OID 18771)
-- Name: fk_organization_proposal; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY proposal
    ADD CONSTRAINT fk_organization_proposal FOREIGN KEY (organization_id) REFERENCES contractor(id) ON UPDATE CASCADE;


--
-- TOC entry 2542 (class 2606 OID 18688)
-- Name: fk_parent_group_item; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY group_item
    ADD CONSTRAINT fk_parent_group_item FOREIGN KEY (parent_id) REFERENCES group_item(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2540 (class 2606 OID 18693)
-- Name: fk_person_employee; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY employee
    ADD CONSTRAINT fk_person_employee FOREIGN KEY (person_id) REFERENCES person(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2541 (class 2606 OID 18698)
-- Name: fk_post_employee; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY employee
    ADD CONSTRAINT fk_post_employee FOREIGN KEY (post_id) REFERENCES okpdtr(id) ON UPDATE CASCADE ON DELETE SET NULL;


--
-- TOC entry 2553 (class 2606 OID 18703)
-- Name: fk_product_item_product; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_product
    ADD CONSTRAINT fk_product_item_product FOREIGN KEY (element_id) REFERENCES specification(id) ON UPDATE CASCADE;


--
-- TOC entry 2570 (class 2606 OID 18708)
-- Name: fk_product_specification; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY specification
    ADD CONSTRAINT fk_product_specification FOREIGN KEY (product_id) REFERENCES product(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2534 (class 2606 OID 18713)
-- Name: fk_source_column_item; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY column_item
    ADD CONSTRAINT fk_source_column_item FOREIGN KEY (source_id) REFERENCES table_property(id) ON UPDATE CASCADE;


--
-- TOC entry 2558 (class 2606 OID 18718)
-- Name: fk_source_item_tax; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_tax
    ADD CONSTRAINT fk_source_item_tax FOREIGN KEY (source_id) REFERENCES article(id) ON UPDATE CASCADE;


--
-- TOC entry 2548 (class 2606 OID 18723)
-- Name: fk_specification_item_material; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_material
    ADD CONSTRAINT fk_specification_item_material FOREIGN KEY (specification_id) REFERENCES specification(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2551 (class 2606 OID 18728)
-- Name: fk_specification_item_operation; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_operation
    ADD CONSTRAINT fk_specification_item_operation FOREIGN KEY (specification_id) REFERENCES specification(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2554 (class 2606 OID 18733)
-- Name: fk_specification_item_product; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_product
    ADD CONSTRAINT fk_specification_item_product FOREIGN KEY (specification_id) REFERENCES specification(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2559 (class 2606 OID 18738)
-- Name: fk_specification_item_tax; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_tax
    ADD CONSTRAINT fk_specification_item_tax FOREIGN KEY (specification_id) REFERENCES specification(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2567 (class 2606 OID 18743)
-- Name: fk_specification_product; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY product
    ADD CONSTRAINT fk_specification_product FOREIGN KEY (specification_id) REFERENCES specification(id) ON UPDATE CASCADE ON DELETE SET NULL;


--
-- TOC entry 2535 (class 2606 OID 18748)
-- Name: fk_table_column_item; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY column_item
    ADD CONSTRAINT fk_table_column_item FOREIGN KEY (table_id) REFERENCES table_property(id) ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2543 (class 2606 OID 18753)
-- Name: fk_table_group_item; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY group_item
    ADD CONSTRAINT fk_table_group_item FOREIGN KEY (table_id) REFERENCES table_property(id) ON UPDATE CASCADE;


--
-- TOC entry 2560 (class 2606 OID 18758)
-- Name: fk_tax_item_tax; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY item_tax
    ADD CONSTRAINT fk_tax_item_tax FOREIGN KEY (element_id) REFERENCES tax(id) ON UPDATE CASCADE;


--
-- TOC entry 2792 (class 0 OID 0)
-- Dependencies: 7
-- Name: public; Type: ACL; Schema: -; Owner: postgres
--

REVOKE ALL ON SCHEMA public FROM PUBLIC;
REVOKE ALL ON SCHEMA public FROM postgres;
GRANT ALL ON SCHEMA public TO postgres;
GRANT ALL ON SCHEMA public TO PUBLIC;


-- Completed on 2017-01-20 13:02:41

--
-- PostgreSQL database dump complete
--

